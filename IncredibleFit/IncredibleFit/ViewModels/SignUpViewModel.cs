using System.Diagnostics;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IncredibleFit.IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;

namespace IncredibleFit.ViewModels
{
    public partial class SignUpViewModel : BaseViewModel
    {
        [GeneratedRegex("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])")]
        private static partial Regex EmailRegex();

        [ObservableProperty]
        private string _email = string.Empty;
        [ObservableProperty]
        private string _firstName = string.Empty;
        [ObservableProperty]
        private string _name = string.Empty;
        [ObservableProperty]
        private string _password = string.Empty;
        [ObservableProperty]
        private string _confirmPassword = string.Empty;


        [ObservableProperty]
        private bool _notAllFilledOut = false;
        [ObservableProperty]
        private bool _emailInvalid = false;
        [ObservableProperty]
        private bool _passwordDoesntMatch = false;
        [ObservableProperty]
        private bool _accountTaken = false;
        [ObservableProperty]
        private bool _errorCreatingAcount = false;


        [RelayCommand]
        private async Task SignUp()
        {
            Reset(false);

            if (string.IsNullOrWhiteSpace(Email)
                || string.IsNullOrWhiteSpace(FirstName)
                || string.IsNullOrWhiteSpace(Name)
                || string.IsNullOrWhiteSpace(Password)
                || string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                NotAllFilledOut = true;
                return;
            }

            if (!EmailRegex().IsMatch(Email))
            {
                EmailInvalid = true;
                return;
            }

            if (!Password.Equals(ConfirmPassword))
            {
                PasswordDoesntMatch = true;
                return;
            }

            User user;
            try
            {
                user = SQLLoginAndSignUp.CreateNewUser(Email, FirstName, Name);
            }
            catch (AccountTakenException)
            {
                AccountTaken = true;
                return;
            }
            
            try
            {
                SQLLoginAndSignUp.UpdatePassword(user, Password);
            }
            catch (UserInvalidException e)
            {
                Debug.WriteLine(e);
                ErrorCreatingAcount = true;
                return;
            }

            await Application.Current!.MainPage!.Navigation.PopAsync();
        }

        internal void Reset(bool text)
        {
            NotAllFilledOut = false;
            EmailInvalid = false;
            PasswordDoesntMatch = false;
            AccountTaken = false;
            ErrorCreatingAcount = false;

            if (!text) return;

            Email = string.Empty;
            FirstName = string.Empty;
            Name = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        }
    }
}
