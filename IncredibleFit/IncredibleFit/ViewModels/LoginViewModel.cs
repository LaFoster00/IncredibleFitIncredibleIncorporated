using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;
using IncredibleFit.Screens;
using System.Text;
using System.Diagnostics;

namespace IncredibleFit.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly SessionInfo _sessionInfo;
        private readonly SignUp _signUp;

        [ObservableProperty]
        private string _userName = "incredible@fit.de";

        [ObservableProperty]
        private string _password = "123";

        public LoginViewModel(SessionInfo sessionInfo, SignUp signUp)
        {
            _sessionInfo = sessionInfo;
            _signUp = signUp;
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
                WHERE EMAIl = '{UserName}'
                """));

            var users = reader.ToObjectList<User>();
            if (!users.Any()) {
                HandleIncorrectUserData();
                return;
            }

            string hashedPassword = PasswordUtil.Hash(Password, users[0].Salt);
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
            Debug.WriteLine("Incorrect user data");
        }

        [RelayCommand]
        public async Task SignUp()
        {
            // Navigate to the signup page
            // You might need to adjust the navigation method based on your application's structure
            await Application.Current!.MainPage!.Navigation.PushAsync(_signUp);
        }
    }
}
