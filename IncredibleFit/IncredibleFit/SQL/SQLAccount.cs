using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;

namespace IncredibleFit.IncredibleFit.SQL
{
    public class AccountTakenException : Exception
    {
        public AccountTakenException() {}
        public AccountTakenException(string message) : base(message) {}
        public AccountTakenException(string message, Exception inner) : base(message, inner) {}
    }

    public class UserInvalidException : Exception
    {
        public UserInvalidException() { }
        public UserInvalidException(string message) : base(message) { }
        public UserInvalidException(string message, Exception inner) : base(message, inner) { }
    }

    public static class SQLAccount
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

        public static void UpdatePassword(User user, in string password)
        {
            if (string.IsNullOrEmpty(user.Salt))
            {
                throw new UserInvalidException("User doesn't have salt and therefore doesn't exist.");
            }

            user.Password = PasswordUtil.Hash(password, user.Salt);
            OracleDatabase.UpdateObject(user);
        }

        public static User CreateNewUser(in string email, in string firstName, in string name)
        {
            User? user = SQLAccount.GetUserWithEmail(email);
            if (user != null)
            {
                throw new AccountTakenException();
            }

            user = new User(email, firstName, name);
            OracleDatabase.InsertObject(user);
            return user;
        }

        public static void DeleteAccount(in User account)
        {
            OracleDatabase.DeleteObject(account);
        }
    }
}
