// Written by Lasse Foster https://github.com/LaFoster00

using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;

namespace IncredibleFit.SQL
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

    /// <summary>
    /// Methods for accessing account information 
    /// </summary>
    public static class SQLAccount
    {
        /// <summary>
        /// Returns a user in case it exists in the database or null
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Updates the password for a user in case it is existent in the database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <exception cref="UserInvalidException">Thrown if user is not valid</exception>
        public static void UpdatePassword(User user, in string password)
        {
            if (string.IsNullOrEmpty(user.Salt))
            {
                throw new UserInvalidException("User doesn't have salt and therefore doesn't exist or isn't correctly initialized.");
            }

            user.Password = PasswordUtil.Hash(password, user.Salt);
            OracleDatabase.UpdateObject(user);
        }

        /// <summary>
        /// Creates a new user without a password.
        /// This call will also populate the salt field in the User.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="AccountTakenException">Thrown if user is already existent in the database</exception>
        public static User CreateNewUser(in string email, in string firstName, in string name)
        {
            User? user = GetUserWithEmail(email);
            if (user != null)
            {
                throw new AccountTakenException();
            }

            user = new User(email, firstName, name);
            OracleDatabase.InsertObject(user);
            return user;
        }

        /// <summary>
        /// Deletes a User
        /// </summary>
        /// <param name="account"></param>
        public static void DeleteAccount(in User account)
        {
            OracleDatabase.DeleteObject(account);
        }
    }
}
