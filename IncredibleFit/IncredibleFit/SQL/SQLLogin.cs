using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;

namespace IncredibleFit.IncredibleFit.SQL
{
    public static class SQLLogin
    {
        public static User? GetUserWithEmail(in string email)
        {
            var reader = OracleDatabase.ExecuteQuery(OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "USER"
                 WHERE EMAIl = '{email}'
                 """));

            var users = reader.ToObjectList<User>();
            return users.Any() ? users[0] : null;
        }
    }
}
