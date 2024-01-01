using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.IncredibleFit.SQL
{
    class OracleDatabase : IDisposable, IAsyncDisposable
    {
        private static OracleDatabase? _instance = null;

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
            { OracleDbType.Single, typeof(object[])}, // --> not validated
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
            // Add more as needed
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
            // Add more as needed
        };

        private OracleConnection? connection = null;

        private OracleDatabase()
        {
        }

        public static void Connect(string username, string password)
        {
            if (Instance.connection != null)
            {
                Debug.WriteLine("Oracle Connection already established.");
                return;
            }

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
            catch (Exception ex)
            {
                Instance.connection = null;
                Debug.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Debug.WriteLine(ex.InnerException.Message);
                    if (ex.InnerException.InnerException != null)
                    {
                        Debug.WriteLine(ex.InnerException.InnerException);
                    }
                }
            }
        }

        public static OracleDataReader? ExecuteQuery(OracleCommand command)
        {
            if (Instance.connection == null)
                return null;

            try
            {
                var reader = command!.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
            }

            return null;
        }

        public static OracleCommand CreateCommand(string command)
        {
            return new OracleCommand(command, Instance.connection);
        }

        public static Entity? GetEntityAttribute(TypeInfo info)
        {
            return info.GetCustomAttribute<Entity>();
        }


        private static readonly Dictionary<Type, (OracleCommand command, IReadOnlyList<PropertyInfo> parameters)> TypeInsertCommands = new();
        private static (OracleCommand command, IReadOnlyList<PropertyInfo> parameters) GetInsertCommand<T>()
        {
            if (TypeInsertCommands.ContainsKey(typeof(T)))
                return TypeInsertCommands[typeof(T)];

            var commandBuilder = new StringBuilder();
            commandBuilder.Append("INSERT INTO ");

            #region RetreiveTableName
            var typeInfo = typeof(T).GetTypeInfo();
            var entityName = GetEntityAttribute(typeInfo);
            commandBuilder.Append(entityName!.name).Append(' ');
            #endregion

            var parameters = GetParameterList(typeof(T));

            #region AddParamsAndValueParams
            commandBuilder.Append('(');
            for (var i = 0; i < parameters.Count; i++)
            {
                var (name, dbType, propertyInfo) = parameters[i];
                commandBuilder.Append(name).Append(i < parameters.Count - 1 ? ", " : "");
            }

            commandBuilder.Append(")\nVALUES (");
            for (var i = 0; i < parameters.Count; i++)
            {
                var (name, dbType, propertyInfo) = parameters[i];
                commandBuilder.Append(':').Append(name).Append(i < parameters.Count - 1 ? ", " : "");
            }

            commandBuilder.Append(')');
            #endregion

            TypeInsertCommands.Add(
                typeof(T),
                (SetupCommandWithParams(commandBuilder, parameters), parameters.Select(tuple => tuple.Item3).ToList()));
            return TypeInsertCommands[typeof(T)];
        }

        public static void InsertObject<T>(T o)
        {
            if (Instance.connection == null)
                return;

            var entityName = GetEntityAttribute(typeof(T).GetTypeInfo());
            if (entityName == null)
                return;

            ExecuteCommandWithObjectData(GetInsertCommand<T>(), o);
        }


        public static void InsertObjects<T>(List<T> objects)
        {
            if (Instance.connection == null)
                return;

            using var transaction = Instance.connection.BeginTransaction();
            foreach (var o in objects)
            {
                InsertObject<T>(o);
            }
            transaction.Commit();
        }

        private static void ExecuteCommandWithObjectData(in (OracleCommand command, IReadOnlyList<PropertyInfo> parameters) c, in object o)
        {
            for (var index = 0; index < c.parameters.Count; index++)
            {
                var propertyInfo = c.parameters[index];
                var value = propertyInfo.GetValue(o);
                c.command!.Parameters[index].Direction = ParameterDirection.InputOutput;
                if (value == null || propertyInfo.GetCustomAttribute<AutoIncrement>() != null)
                    c.command!.Parameters[index].Value = DBNull.Value;
                else
                    c.command!.Parameters[index].Value = propertyInfo.GetValue(o);
            }

            try
            {
                c.command.ExecuteNonQuery();
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

        private static OracleCommand SetupCommandWithParams(in StringBuilder commandBuilder, in IReadOnlyList<(string name, OracleDbType type, PropertyInfo property)> parameters)
        {
            var command = CreateCommand(commandBuilder.ToString());
            command.CommandType = CommandType.Text;
            foreach (var param in parameters)
            {
                command!.Parameters.Add($"{param.name}", param.type);
            }

            return command;
        }

        private static List<(string name, OracleDbType type, PropertyInfo property)> GetParameterList(Type type)
        { 
            var parameters = new List<ValueTuple<string, OracleDbType, PropertyInfo>>();
            foreach (var propertyInfo in type.GetProperties())
            {
                if (propertyInfo.SetMethod != null && propertyInfo.SetMethod.IsPrivate &&
                    propertyInfo.GetCustomAttribute<AutoIncrement>() == null)
                    continue;
                var fieldAttribute = propertyInfo.GetCustomAttribute<Field>();
                if (fieldAttribute == null)
                    continue;
                if (fieldAttribute.Mapping == null)
                {
                    Type propType = propertyInfo.PropertyType;
                    if (Nullable.GetUnderlyingType(propType) != null)
                        propType = Nullable.GetUnderlyingType(propType) ?? throw new InvalidOperationException();

                    parameters.Add(new ValueTuple<string, OracleDbType, PropertyInfo>(
                        fieldAttribute.Name,
                        TypeToDb[propType],
                        propertyInfo)
                    );
                }
                else
                {
                    parameters.Add(new ValueTuple<string, OracleDbType, PropertyInfo>(
                        fieldAttribute.Name,
                        fieldAttribute.Mapping.Value,
                        propertyInfo)
                    );
                }
            }

            return parameters;
        }

        public static void CloseConnection()
        {
            Instance.connection?.Close();
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