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

        public static Dictionary<Type, DbType> TypeToDb = new()
        {
            { typeof(byte), DbType.Byte },
            { typeof(sbyte), DbType.SByte },
            { typeof(short), DbType.Int16 },
            { typeof(ushort), DbType.UInt16 },
            { typeof(int), DbType.Int32 },
            { typeof(uint), DbType.UInt32 },
            { typeof(long), DbType.Int64 },
            { typeof(ulong), DbType.UInt64 },
            { typeof(float), DbType.Single },
            { typeof(double), DbType.Double },
            { typeof(decimal), DbType.Decimal },
            { typeof(bool), DbType.Boolean },
            { typeof(string), DbType.String },
            { typeof(char), DbType.StringFixedLength },
            { typeof(Guid), DbType.Guid },
            { typeof(DateTime), DbType.DateTime },
            { typeof(DateTimeOffset), DbType.DateTimeOffset }
        };

        public static Dictionary<DbType, Type> DbToType = TypeToDb.ToDictionary(kv => kv.Value, kv => kv.Key);

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

        public static void InsertObjects<T>(List<T> objects)
        {
            if (Instance.connection == null)
                return;

            using var transaction = Instance.connection.BeginTransaction();

            var commandBuilder = new StringBuilder();
            commandBuilder.Append("INSERT INTO ");

            #region RetreiveTableName
            var typeInfo = typeof(T).GetTypeInfo();
            var entityName = typeInfo.GetCustomAttribute<Entity>();
            if (entityName == null)
                return;
            commandBuilder.Append(entityName.name);
            #endregion

            #region SetupParamList
            var parameters = new List<Tuple<string, DbType, PropertyInfo>>();
            foreach (var propertyInfo in typeInfo.GetProperties())
            {
                if (propertyInfo.SetMethod != null && propertyInfo.SetMethod.IsPrivate)
                    continue;
                var fieldAttribute = propertyInfo.GetCustomAttribute<Field>();
                if (fieldAttribute == null)
                    continue;
                parameters.Add(new Tuple<string, DbType, PropertyInfo>(
                    fieldAttribute.name,
                    TypeToDb[propertyInfo.PropertyType],
                    propertyInfo)
                );
            }
            #endregion

            #region AddParamsAndValueParams
            commandBuilder.Append('(');
            foreach (var (name, dbType, propertyInfo) in parameters)
            {
                commandBuilder.Append(name);
            }

            commandBuilder.Append(") \n" +
                                  "VALUES (");
            foreach (var (name, dbType, propertyInfo) in parameters)
            {
                commandBuilder.Append('@').Append(name);
            }

            commandBuilder.Append(")");
            #endregion

            #region CreateCommandAndAddParams
            using var command = CreateCommand(commandBuilder.ToString());
            foreach (var (name, dbType, propertyInfo) in parameters)
            {
                command!.Parameters.Add($"@{name}", dbType);
            }
            #endregion

            #region InsertDataIntoDb
            try
            {
                foreach (var o in objects)
                {
                    for (var index = 0; index < parameters.Count; index++)
                    {
                        var (name, dbType, propertyInfo) = parameters[index];
                        command!.Parameters[index].Value = propertyInfo.GetValue(o);
                    }

                    command!.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            #endregion
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