#nullable enable
using System.Diagnostics;
using System.Threading;
using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.IncredibleFit.SQL
{
    internal class OracleDatabase : IDisposable, IAsyncDisposable
    {
        private static OracleDatabase? _instance = null;
        public static OracleDatabase Instance
        {
            get => _instance ??= new OracleDatabase();
            private set => _instance = value;
        }

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

        public static OracleDataReader? ExecuteSqlQuery(OracleConnection connection, string query)
        {
            using var command = new OracleCommand(query, connection);
            try
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Process the data, e.g., retrieve values from columns
                    Console.WriteLine($"Column1: {reader["Column1"]}, Column2: {reader["Column2"]}");
                }

                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
            }

            return null;
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