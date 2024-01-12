using System.Security.Cryptography;
using System.Text;

namespace IncredibleFit
{
    public static class PasswordUtil

    {
        public static readonly int KeySize = 64;
        public static readonly int Iterations = 350000;
        public static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;

        public static string Hash(in string password, in string salt)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var saltBytes = Encoding.UTF8.GetBytes(salt);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                passwordBytes,
                saltBytes,
                Iterations,
                HashAlgorithm,
                KeySize);
            return Convert.ToHexString(hash);
        }
    }
}
