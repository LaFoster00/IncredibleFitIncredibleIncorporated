﻿// Written by Lasse Foster https://github.com/LaFoster00

using System;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using Oracle.ManagedDataAccess.Client;
using static IncredibleFit.SQL.OracleDatabase;

namespace IncredibleFit.SQL
{
    internal static class DbExtensions
    {
        /// <summary>
        /// Converts oracle objects to their .net equivalent in case it is an oracle object
        /// </summary>
        /// <param name="o"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static object? ToSystemObject(this object? o, CommandParameter c)
        {
            return o.ToSystemObject(c.PropertyInfo.PropertyType, c.Type);
        }
    }

    /// <summary>
    /// Wrapper class around the Oracle Database specific code and basic database operations 
    /// </summary>
    public partial class OracleDatabase : ObservableObject, IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// All information required for an OracleCommand Parameter
        /// </summary>
        internal struct CommandParameter
        {
            public readonly string Name;
            public readonly PropertyInfo PropertyInfo;
            public ParameterDirection Direction;
            public readonly OracleDbType Type;
            public readonly int Size;
            public readonly string? CreateRoutine;

            public CommandParameter(
                string name,
                PropertyInfo propertyInfo,
                ParameterDirection direction,
                OracleDbType type,
                int size,
                string? createRoutine)
            {
                Name = name;
                PropertyInfo = propertyInfo;
                Direction = direction;
                Type = type;
                Size = size;
                CreateRoutine = createRoutine;
            }
        }

        // Status information about the current connection
        [ObservableProperty]
        private bool _connected = false;

        [ObservableProperty]
        private bool _connecting = false;

        [ObservableProperty]
        private bool _connectionFailed = false;

        // The current connection
        private OracleConnection? connection = null;

        // The oracle database singleton instance
        private static OracleDatabase? _instance = null;

        // The prefix for all generated return parameters
        private static readonly string GeneratedExt = "generated";

        /// <summary>
        /// The OracleDatabase singleton accessor
        /// </summary>
        public static OracleDatabase Instance
        {
            get => _instance ??= new OracleDatabase();
            private set => _instance = value;
        }

        // https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/oracle-data-type-mappings
        public static Dictionary<OracleDbType, Type> DbToType = new()
        {
            { OracleDbType.Char, typeof(string) },
            { OracleDbType.NChar, typeof(string) },
            { OracleDbType.Date, typeof(DateTime) },
            { OracleDbType.IntervalDS, typeof(TimeSpan) },
            { OracleDbType.IntervalYM, typeof(long) },
            { OracleDbType.Long, typeof(string) },
            { OracleDbType.Raw, typeof(byte[]) },
            { OracleDbType.LongRaw, typeof(byte[]) },
            { OracleDbType.Int16, typeof(short)},
            { OracleDbType.Int32, typeof(int)},
            { OracleDbType.Int64, typeof(long)},
            { OracleDbType.Single, typeof(float)}, // --> not validated
            { OracleDbType.BinaryFloat, typeof(float) },
            { OracleDbType.Double, typeof(double)}, // --> not validated
            { OracleDbType.BinaryDouble, typeof(double) },
            { OracleDbType.Decimal, typeof(decimal) },
            { OracleDbType.BFile, typeof(byte[]) },
            { OracleDbType.Blob, typeof(byte[]) },
            { OracleDbType.Clob, typeof(string) },
            { OracleDbType.Json, typeof(string) },
            { OracleDbType.TimeStamp, typeof(DateTime) },
            { OracleDbType.TimeStampTZ, typeof(DateTime) },
            { OracleDbType.TimeStampLTZ, typeof(DateTime) },
            { OracleDbType.Array, typeof(List<object>)}, // --> not validated
            { OracleDbType.Ref, typeof(string) },
            { OracleDbType.Varchar2, typeof(string) },
            { OracleDbType.NVarchar2, typeof(string) },
            { OracleDbType.Object, typeof(object) },
            { OracleDbType.ObjectAsJson, typeof(string) },
        };

        public static Dictionary<Type, OracleDbType> TypeToDb = new()
        {
            { typeof(DateTime), OracleDbType.Date },
            { typeof(decimal), OracleDbType.Decimal },
            { typeof(byte), OracleDbType.Byte },
            { typeof(short), OracleDbType.Int16 },
            { typeof(int), OracleDbType.Int32 },
            { typeof(long), OracleDbType.Int64 },
            { typeof(float), OracleDbType.Single },
            { typeof(double), OracleDbType.Double },
            { typeof(bool), OracleDbType.Boolean },
            { typeof(string), OracleDbType.Varchar2 },
            { typeof(byte[]), OracleDbType.Raw },
            { typeof(DateTimeOffset), OracleDbType.TimeStampTZ },
        };

        private OracleDatabase()
        {
        }

        /// <summary>
        /// Connects this app to the Oracle Database Server using the HSBI server info
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async Task Connect(string username, string password)
        {
            if (Instance.connection != null)
            {
                Debug.WriteLine("Oracle Connection already established.");
                return;
            }

            Instance.Connecting = true;

            OracleConfiguration.TraceFileLocation = "E:\\";

            const string host = "rs03-db-inf-min.ad.fh-bielefeld.de";
            const int port = 1521;
            const string sid = "orcl";

            var connectionString = $"Data Source = " +
                                        $"(DESCRIPTION = " +
                                        $"(ADDRESS_LIST = " +
                                            $"(ADDRESS = " +
                                                $"(PROTOCOL = TCP)" +
                                                $"(HOST = {host})" +
                                                $"(PORT = {port})" +
                                            $")" +
                                        $")" +
                                        $"(CONNECT_DATA = " +
                                            $"(SERVER = DEDICATED)" +
                                            $"(SID = {sid})" +
                                        $")" +
                                    $"); " +
                                    $"User Id = {username}; " +
                                    $"Password = {password};";

            Debug.WriteLine($"Database Connection-String:\n\t{connectionString}");

            Instance.connection = new OracleConnection(connectionString);
            try
            {
                await Instance.connection.OpenAsync();
                Debug.WriteLine("Connected to Oracle Database");
                Instance.Connected = true;
                Instance.ConnectionFailed = false;
            }
            catch (Exception e)
            {
                Instance.Connecting = false;
                Instance.ConnectionFailed = true;
                Instance.connection = null;
                Debug.WriteLine(e);
                var inner = e.InnerException;
                while (inner != null)
                {
                    Debug.WriteLine(inner);
                    inner = inner.InnerException;
                }
            }
        }

        /// <summary>
        /// Creates an OracleCommand containing the specified command string and the current OracleConnection.
        /// The Command is also set to bind by name so that parameter order is irrelevant.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static OracleCommand CreateCommand(in string command)
        {
            var cmd = new OracleCommand(command, Instance.connection);
            cmd.BindByName = true;
            return cmd;
        }

        /// <summary>
        /// Executes an OracleCommand query.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>OracleDataReader containing the records of the query or null if command fails.</returns>
        public static OracleDataReader? ExecuteQuery(in OracleCommand command)
        {
            if (Instance.connection == null)
                return null;

            try
            {
                var reader = command!.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                var inner = e.InnerException;
                while (inner != null)
                {
                    Debug.WriteLine(inner);
                    inner = inner.InnerException;
                }
            }

            return null;
        }

        /// <summary>
        /// Executes non query oracle command
        /// </summary>
        /// <param name="command"></param>
        public static void ExecuteNonQuery(in OracleCommand command)
        {
            if (Instance.connection == null)
                return;

            try
            {
                command!.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                var inner = e.InnerException;
                while (inner != null)
                {
                    Debug.WriteLine(inner);
                    inner = inner.InnerException;
                }
            }
        }

        /// <summary>
        /// Executes non query with specified object's data
        /// </summary>
        /// <param name="c"></param>
        /// <param name="o"></param>
        private static void ExecuteCommandWithObjectData(
            in (OracleCommand command, IReadOnlyList<CommandParameter> parameters) c,
            in object o)
        {
            foreach (var param in c.parameters)
            {
                if (param.Direction is ParameterDirection.Output or ParameterDirection.ReturnValue)
                    continue;

                var value = param.PropertyInfo.GetValue(o);
                c.command.Parameters[$"P{param.Name}"].Value = value.FromDomain() ?? DBNull.Value;
            }

            try
            {
                c.command.ExecuteNonQuery();

                foreach (var param in c.parameters)
                {
                    if (param.Direction is ParameterDirection.Input)
                    {
                        continue;
                    }
                    param.PropertyInfo.SetValue(o,
                        c.command.Parameters[$"{GeneratedExt}{param.Name}"].Value.ToSystemObject(param));
                }
            }
            catch (OracleException e)
            {
                Debug.WriteLine(e);
                var inner = e.InnerException;
                while (inner != null)
                {
                    Debug.WriteLine(inner);
                    inner = inner.InnerException;
                }
            }
        }

        /// <summary>
        /// Inserts the specified object into the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        public static void InsertObject<T>(in T? o)
        {
            if (Instance.connection == null || o == null)
                return;

            if (typeof(T).TryGetEntity() == null)
                return;

            ExecuteCommandWithObjectData(GetInsertCommand<T>(), o);
        }

        /// <summary>
        /// Inserts multiple objects into the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objects"></param>
        public static void InsertObjects<T>(in IReadOnlyList<T> objects)
        {
            if (Instance.connection == null)
                return;

            using var transaction = Instance.connection.BeginTransaction();
            foreach (var o in objects)
            {
                InsertObject(o);
            }
            transaction.Commit();
        }

        /// <summary>
        /// Updates the specified object in the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        public static void UpdateObject<T>(in T? o)
        {
            if (Instance.connection == null || o == null)
                return;

            if (typeof(T).TryGetEntity() == null)
                return;

            ExecuteCommandWithObjectData(GetUpdateCommand<T>(), o);

        }

        /// <summary>
        /// Deletes an object from the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        public static void DeleteObject<T>(in T? o)
        {
            if (Instance.connection == null || o == null)
                return;

            if (typeof(T).TryGetEntity() == null)
                return;

            ExecuteCommandWithObjectData(GetDeleteCommand<T>(), o);
        }

        /// <summary>
        /// Creates and populates an OracleCommand and its parameters with the command parameters given.
        /// </summary>
        /// <param name="commandBuilder"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static OracleCommand SetupCommandWithParams(
            in StringBuilder commandBuilder,
            in IReadOnlyList<CommandParameter> parameters)
        {
            var command = CreateCommand(commandBuilder.ToString());
            command.CommandType = CommandType.Text;
            foreach (var param in parameters)
            {
                if (param.Direction is ParameterDirection.Output or ParameterDirection.ReturnValue)
                {
                    command.Parameters.Add($"{GeneratedExt}{param.Name}", param.Type, param.Direction);
                    command.Parameters[$"{GeneratedExt}{param.Name}"].Size = param.Size;
                }

                if (param.Direction is not (ParameterDirection.Output or ParameterDirection.ReturnValue))
                {
                    command.Parameters.Add($"P{param.Name}", param.Type, param.Direction);
                }
            }

            return command;
        }

        private static readonly Dictionary<Type, (List<CommandParameter> NoReadBack, List<CommandParameter> ReadBack)> TypeParamters = new();

        /// <summary>
        /// Gets the parameters for a type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="readBack"></param>
        /// <returns>If readBack disabled, list with only input parameters, else list with output and return parameters included</returns>
        // Marks private setters as output values to be set in class after operation
        private static List<CommandParameter> GetParameterList(in Type type, in bool readBack)
        {
            if (TypeParamters.TryGetValue(type, out var ps))
                return readBack ? ps.ReadBack : ps.NoReadBack;

            TypeParamters.Add(type,
                (GenerateParameterList(type, false), GenerateParameterList(type, true)));
            return readBack ? TypeParamters[type].ReadBack : TypeParamters[type].NoReadBack;
        }
        
        /// <summary>
        /// Internal function only.
        /// Generates the parameter list with or without read back parameters
        /// </summary>
        /// <param name="type"></param>
        /// <param name="readBack"></param>
        /// <returns></returns>
        private static List<CommandParameter> GenerateParameterList(in Type type, in bool readBack)
        {
            var parameters = new List<CommandParameter>();
            foreach (var propertyInfo in type.GetProperties())
            {
                var direction = ParameterDirection.Input;
                if (propertyInfo.SetMethod != null && propertyInfo.SetMethod.IsPrivate)
                    if (readBack)
                        direction = ParameterDirection.Output;
                    else
                        continue;

                var fieldAttribute = propertyInfo.TryGetField();
                if (fieldAttribute == null)
                    continue;

                parameters.Add(new CommandParameter(
                    fieldAttribute.Name,
                    propertyInfo,
                    direction,
                    GetOracleDbType(propertyInfo, fieldAttribute),
                    fieldAttribute.Size,
                    propertyInfo.TryGetCreateSubroutine())
                );

            }

            return parameters;
        }

        /// <summary>
        /// Finds all fields marked with an id property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="direction"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private static List<CommandParameter> GetIdProperties<T>(ParameterDirection direction)
        {
            var idProperties = typeof(T).GetProperties().Where(info => info.TryGetField() != null && info.TryGetId() != null);
            if (!idProperties.Any())
            {
                throw new InvalidOperationException("No id field specified in this class. Can't update object without");
            }

            return (from info in idProperties
                    let field = info.TryGetField()!
                    let name = field.Name
                    let type = GetOracleDbType(info, field)
                    select new CommandParameter(name, info, direction, type, field.Size, info.TryGetCreateSubroutine())
                ).ToList();
        }

        /// <summary>
        /// Creates the RETURNING sql statement for all output and return parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static string CreateReturnStatement(IReadOnlyList<CommandParameter> parameters)
        {
            bool hasReturn = false;
            StringBuilder vars = new("\nRETURNING ");
            StringBuilder ids = new(" INTO ");
            var numParams = 0;
            foreach (var param in parameters)
            {
                if (param.Direction is ParameterDirection.Input)
                    continue;
                hasReturn = true;
                vars.Append(numParams > 0 ? ", " : "").Append($"\"{param.Name}\"");
                ids.Append(numParams > 0 ? ", " : "").Append($":{GeneratedExt}{param.Name}");
                numParams++;
            }

            return hasReturn ? vars.Append(ids).ToString() : string.Empty;
        }

        /// <summary>
        /// Creates the WHERE statements for all the id parameters
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="idProperties"></param>
        /// <returns></returns>
        private static string CreateWhereStatement(Entity entity, IReadOnlyList<CommandParameter> idProperties)
        {
            var statement = new StringBuilder();
            statement.Append($"WHERE ");
            for (var index = 0; index < idProperties.Count; index++)
            {
                var id = idProperties[index];
                statement.Append($"\"{entity.Name}\".\"{id.Name}\" = :P{id.Name}").Append(index < (idProperties.Count - 1) ? " and " : "");
            }

            return statement.ToString();
        }

        private static readonly Dictionary<Type, (OracleCommand command, IReadOnlyList<CommandParameter> parameters)> TypeInsertCommands = new();
        /// <summary>
        /// Generates an insert command for the given type and caches it for reuse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static (OracleCommand command, IReadOnlyList<CommandParameter> parameters) GetInsertCommand<T>()
        {
            if (TypeInsertCommands.ContainsKey(typeof(T)))
                return TypeInsertCommands[typeof(T)];

            var commandBuilder = new StringBuilder();
            commandBuilder.Append("INSERT INTO ");

            #region RetreiveTableName
            var type = typeof(T);
            commandBuilder.Append($"\"{typeof(T).TryGetEntityName()!}\" ");
            #endregion

            var parameters = GetParameterList(typeof(T), true);

            #region AddParamsAndValueParams
            commandBuilder.Append("(\n");
            for (var i = 0; i < parameters.Count; i++)
            {
                var param = parameters[i];
                if (param.CreateRoutine == null && param.Direction is ParameterDirection.Output or ParameterDirection.ReturnValue)
                    continue;
                commandBuilder.Append($"\t\"{param.Name}\"").Append(i < parameters.Count - 1 ? ",\n" : "");
            }

            commandBuilder.Append(")\nVALUES (");
            for (var i = 0; i < parameters.Count; i++)
            {
                var param = parameters[i];
                if (param.CreateRoutine == null && param.Direction is ParameterDirection.Output or ParameterDirection.ReturnValue)
                    continue;

                if (param.CreateRoutine == null)
                {
                    commandBuilder.Append(":P").Append(param.Name).Append(i < parameters.Count - 1 ? ", " : "");
                }
                else
                {
                    commandBuilder.Append(param.CreateRoutine).Append(i < parameters.Count - 1 ? ", " : "");
                    param.Direction = ParameterDirection.Output;
                    parameters[i] = param;
                }
            }

            commandBuilder.Append(')');

            commandBuilder.Append(CreateReturnStatement(parameters));
            #endregion

            TypeInsertCommands.Add(
                typeof(T),
                (SetupCommandWithParams(commandBuilder, parameters), parameters));
            return TypeInsertCommands[typeof(T)];
        }

        private static readonly Dictionary<Type, (OracleCommand command, IReadOnlyList<CommandParameter> parameters)> TypeUpdateCommands = new();
        /// <summary>
        /// Generates an Update command for a given type and caches it for reuse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static (OracleCommand command, IReadOnlyList<CommandParameter> parameters) GetUpdateCommand<T>()
        {
            if (TypeUpdateCommands.ContainsKey(typeof(T)))
                return TypeUpdateCommands[typeof(T)];

            var commandBuilder = new StringBuilder();
            commandBuilder.Append("UPDATE ");

            #region RetreiveTableName

            var entity = typeof(T).TryGetEntity()!;
            commandBuilder.Append($"\"{entity.Name}\"");

            #endregion

            var parameters = GetParameterList(typeof(T), false);

            #region AddParamsAndValueParams

            commandBuilder.Append("\nSET");
            for (var i = 0; i < parameters.Count; i++)
            {
                var param = parameters[i];
                commandBuilder.Append($"\t\"{param.Name}\" = :P{param.Name}")
                    .Append(i < parameters.Count - 1 ? "," : "").Append('\n');
            }

            var idProperties = GetIdProperties<T>(ParameterDirection.Input);
            parameters.AddRange(idProperties);

            commandBuilder.Append(CreateWhereStatement(entity, idProperties));

            #endregion

            TypeUpdateCommands.Add(
                typeof(T),
                (SetupCommandWithParams(commandBuilder, parameters), parameters));
            return TypeUpdateCommands[typeof(T)];
        }

        private static readonly Dictionary<Type, (OracleCommand command, IReadOnlyList<CommandParameter> parameters)> TypeDeleteCommands = new();
        /// <summary>
        /// Generates a delete command for a given type and caches it for reuse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static (OracleCommand command, IReadOnlyList<CommandParameter> parameters) GetDeleteCommand<T>()
        {
            if (TypeDeleteCommands.ContainsKey(typeof(T)))
                return TypeDeleteCommands[typeof(T)];

            var commandBuilder = new StringBuilder();
            commandBuilder.Append("DELETE FROM ");

            #region RetreiveTableName
            var entity = typeof(T).TryGetEntity()!;
            commandBuilder.Append($"\"{entity.Name}\"\n");
            #endregion

            #region AddParamsAndValueParams
            var parameters = new List<CommandParameter>();
            var idProperties = GetIdProperties<T>(ParameterDirection.Input);
            parameters.AddRange(idProperties);

            commandBuilder.Append(CreateWhereStatement(entity, idProperties));

            #endregion

            TypeDeleteCommands.Add(
                typeof(T),
                (SetupCommandWithParams(commandBuilder, parameters), parameters));
            return TypeDeleteCommands[typeof(T)];
        }

        /// <summary>
        /// Get the fields specified OracleDbType or looks up its implicit mapping using TypeToDb
        /// </summary>
        /// <param name="info"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        private static OracleDbType GetOracleDbType(PropertyInfo info, Field field)
        {
            if (field.Type == null)
            {
                return TypeToDb[info.PropertyType.GetNullableUnderlying()];
            }
            else
            {
                return field.Type.Value;
            }
        }

        public static void CloseConnection()
        {
            Instance.connection?.Close();
            Instance.Connected = false;
        }

        public void Dispose()
        {
            Connected = false;
            connection?.Dispose();
            connection = null;
        }

        public async ValueTask DisposeAsync()
        {
            Connected = false;
            if (connection != null)
                await connection.DisposeAsync();
            connection = null;
        }
    }
}