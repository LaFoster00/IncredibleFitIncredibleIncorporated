using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;
using IncredibleFit.Screens;
using System.Security.Cryptography;
using System.Text;

namespace IncredibleFit.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly SessionInfo _sessionInfo;

        [ObservableProperty]
        private string _userName = string.Empty;

        [ObservableProperty]
        private string _password = string.Empty;

        private const int keySize = 64;
        private const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public LoginViewModel(SessionInfo sessionInfo)
        {
            _sessionInfo = sessionInfo;
        }

        string HashPasword(in string password, in byte[] salt)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);
        }

        [RelayCommand]
        public async Task Login()
        {
            IsBusy = true;

            if (string.IsNullOrWhiteSpace(UserName) && string.IsNullOrWhiteSpace(Password))
                return;

            var reader = OracleDatabase.ExecuteQuery(OracleDatabase.CreateCommand(
                $"""
                SELECT * FROM "USER"
                WHERE EMAIl = {UserName}
                """));

            var users = reader.ToObjectList<User>();
            if (!users.Any()) {
                HandleIncorrectUserData();
                return;
            }

            string hashedPassword = HashPasword(Password, Encoding.UTF8.GetBytes(users[0].Salt));
            if (!hashedPassword.Equals(users[0].Password))
            {
                HandleIncorrectUserData();
                return;
            }

            _sessionInfo.User = users[0];

            await Shell.Current.GoToAsync("//Profile");

            IsBusy = false;
        }

        private void HandleIncorrectUserData()
        {
            throw new NotImplementedException();
        }

        [RelayCommand]
        public async Task SignUp()
        {
            // Navigate to the signup page
            // You might need to adjust the navigation method based on your application's structure
            Application.Current.MainPage.Navigation.PushAsync(new SignUp());
        }
    }
}
