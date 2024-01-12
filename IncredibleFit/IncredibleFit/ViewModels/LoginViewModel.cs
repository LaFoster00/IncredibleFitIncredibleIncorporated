using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;
using IncredibleFit.Screens;
using System.Text;
using System.Diagnostics;
using IncredibleFit.IncredibleFit.SQL;

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

        [ObservableProperty] 
        private bool _wrongCredentials = false;

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

            User? user = SQLAccount.GetUserWithEmail(UserName);
            
            if (user == null)
            {
                WrongCredentials = true;
                IsBusy = false;
                return;
            }

            string hashedPassword = PasswordUtil.Hash(Password, user.Salt);
            if (!hashedPassword.Equals(user.Password))
            {
                WrongCredentials = true;
                IsBusy = false;
                return;
            }

            _sessionInfo.User = user;

            await Shell.Current.GoToAsync("//Profile");

            IsBusy = false;
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
