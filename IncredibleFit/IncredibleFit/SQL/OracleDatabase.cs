using System;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace IncredibleFit.SQL
{ 
    class OracleDatabase : IDisposable, IAsyncDisposable
    {
        private struct CommandParameter
        {
            public readonly string Name;
            public readonly PropertyInfo PropertyInfo;
            public readonly ParameterDirection Direction;
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

        private static OracleDatabase? _instance = null;
        private static readonly string GeneratedExt = "generated";

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

        private OracleConnection? connection = null;

        private OracleDatabase()
        {
        }

        public static void Connect(in string username, in string password)
        {
            if (Instance.connection != null)
            {
                Debug.WriteLine("Oracle Connection already established.");
                return;
            }

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
                Instance.connection.Open();
                Debug.WriteLine("Connected to Oracle Database");
            }
            catch (Exception e)
            {
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

        public static OracleCommand CreateCommand(in string command)
        {
            var cmd = new OracleCommand(command, Instance.connection);
            cmd.BindByName = true;
            return cmd;
        }

        public static void InsertObject<T>(in T? o)
        {
            if (Instance.connection == null || o == null)
                return;

            var entityName = typeof(T).GetEntity();
            if (entityName == null)
                return;

            ExecuteCommandWithObjectData(GetInsertCommand<T>(), o);
        }


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

        public static void UpdateObject<T>(in T? o)
        {
            if (Instance.connection == null || o == null)
                return;

            var entityName = typeof(T).GetEntity();
            if (entityName == null)
                return;

            ExecuteCommandWithObjectData(GetUpdateCommand<T>(), o);

        }

        private static readonly Dictionary<Type, (OracleCommand command, IReadOnlyList<CommandParameter> parameters)> TypeInsertCommands = new();
        private static (OracleCommand command, IReadOnlyList<CommandParameter> parameters) GetInsertCommand<T>()
        {
            if (TypeInsertCommands.ContainsKey(typeof(T)))
                return TypeInsertCommands[typeof(T)];

            var commandBuilder = new StringBuilder();
            commandBuilder.Append("INSERT INTO \"");

            #region RetreiveTableName
            var type = typeof(T);
            var entityName = typeof(T).GetEntity();
            commandBuilder.Append(entityName!.Name).Append("\" ");
            #endregion

            var parameters = GetParameterList(typeof(T), true);

            #region AddParamsAndValueParams
            commandBuilder.Append("(\n");
            for (var i = 0; i < parameters.Count; i++)
            {
                var param = parameters[i];
                if (param.CreateRoutine == null && param.Direction is ParameterDirection.Output or ParameterDirection.ReturnValue)
                    continue;
                commandBuilder.Append('\t').Append(param.Name).Append(i < parameters.Count - 1 ? ",\n" : "");
            }

            commandBuilder.Append(")\nVALUES (");
            for (var i = 0; i < parameters.Count; i++)
            {
                var param = parameters[i];
                if (param.CreateRoutine == null && param.Direction is ParameterDirection.Output or ParameterDirection.ReturnValue)
                    continue;

                if (param.CreateRoutine == null)
                    commandBuilder.Append(':').Append(param.Name).Append(i < parameters.Count - 1 ? ", " : "");
                else
                    commandBuilder.Append(param.CreateRoutine).Append(i < parameters.Count - 1 ? ", " : "");
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
        private static (OracleCommand command, IReadOnlyList<CommandParameter> parameters) GetUpdateCommand<T>()
        {
            if (TypeUpdateCommands.ContainsKey(typeof(T)))
                return TypeUpdateCommands[typeof(T)];

            var commandBuilder = new StringBuilder();
            commandBuilder.Append("UPDATE \"");

            #region RetreiveTableName
            var type = typeof(T);
            var entityName = type.GetEntity();
            commandBuilder.Append(entityName!.Name).Append("\" ");
            #endregion

            var parameters = GetParameterList(typeof(T), false);

            #region AddParamsAndValueParams
            commandBuilder.Append("\nSET");
            for (var i = 0; i < parameters.Count; i++)
            {
                var param = parameters[i];
                commandBuilder.Append($"\t{param.Name} = :{param.Name}").Append(i < parameters.Count - 1 ? ",\n" : "\n");
            }

            var idProperty = GetIdProperty<T>(ParameterDirection.Input);
            parameters.Add(idProperty);

            commandBuilder.Append($"WHERE {entityName.Name}.{idProperty.Name} = :{idProperty.Name}");
            #endregion

            TypeUpdateCommands.Add(
                typeof(T),
                (SetupCommandWithParams(commandBuilder, parameters), parameters));
            return TypeUpdateCommands[typeof(T)];
        }

        private static void ExecuteCommandWithObjectData(
            in (OracleCommand command, IReadOnlyList<CommandParameter> parameters) c,
            in object o)
        {
            foreach (var param in c.parameters)
            {
                if (param.Direction is ParameterDirection.Output or ParameterDirection.ReturnValue)
                    continue;
                if (param.CreateRoutine != null)
                    continue;

                var value = param.PropertyInfo.GetValue(o);
                c.command.Parameters[param.Name].Value = value ?? DBNull.Value;
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
                    param.PropertyInfo.SetValue(o, ToSystemObject(c.command.Parameters[$"{GeneratedExt}{param.Name}"].Value));
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
                    command.Parameters.Add($"{param.Name}", param.Type, param.Direction);
                }
            }

            return command;
        }

        // Marks private setters as output values to be set in class after operation
        private static List<CommandParameter> GetParameterList(in Type type, in bool readBack)
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

                var fieldAttribute = propertyInfo.GetField();
                if (fieldAttribute == null)
                    continue;

                parameters.Add(new CommandParameter(
                    fieldAttribute.Name,
                    propertyInfo,
                    direction,
                    GetOracleDbType(propertyInfo, fieldAttribute),
                    fieldAttribute.Size,
                    propertyInfo.GetSubroutine())
                );

            }

            return parameters;
        }

        private static CommandParameter GetIdProperty<T>(ParameterDirection direction)
        {
            try
            {
                var info = typeof(T).GetProperties().First(info =>
                    info.GetField() != null && info.GetCustomAttribute<ID>() != null);
                var field = info.GetField()!;
                var name = field.Name;
                var type = GetOracleDbType(info, field);
                return new CommandParameter(name, info, direction, type, field.Size, info.GetSubroutine());
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("No id field specified in this class. Can't update object without");
            }
        }

        private static bool IsNullable(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        private static OracleDbType GetOracleDbType(PropertyInfo info, Field field)
        {
            if (field.Mapping == null)
            {
                Type propType = info.PropertyType;
                if (IsNullable(propType))
                    propType = Nullable.GetUnderlyingType(propType) ?? throw new InvalidOperationException();

                return TypeToDb[propType];
            }
            else
            {
                return field.Mapping.Value;
            }
        }

        private static string CreateReturnStatement(IReadOnlyList<CommandParameter> parameters)
        {
            StringBuilder vars = new("\nRETURNING ");
            StringBuilder ids = new(" INTO ");
            var numParams = 0;
            foreach (var param in parameters)
            {
                if (param.Direction is ParameterDirection.Input)
                    continue;
                vars.Append(numParams > 0 ? ", " : "").Append(param.Name);
                ids.Append(numParams > 0 ? ", " : "").Append($":{GeneratedExt}{param.Name}");
                numParams++;
            }

            return vars.Append(ids).ToString();
        }

        public static void CloseConnection()
        {
            Instance.connection?.Close();
        }

        // Converts oracle objects to their .net equivalent in case it is an oracle object
        private static object? ToSystemObject(object? o)
        {
            if (o is null)
                return null;

            switch (o)
            {
                case OracleDecimal or:
                    return or.Value;
                case OracleString os:
                    return os.Value;
                default:
                    return o;
            }
        }

        public void Dispose()
        {
            connection?.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            if (connection != null) await connection.DisposeAsync();
        }
    }
}