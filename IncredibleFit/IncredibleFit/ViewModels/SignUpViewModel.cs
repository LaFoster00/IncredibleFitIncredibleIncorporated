using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;
using System.Text.RegularExpressions;

namespace IncredibleFit.ViewModels
{
    public partial class SignUpViewModel : BaseViewModel
    {
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
            if (string.IsNullOrWhiteSpace(Email)
                || string.IsNullOrWhiteSpace(FirstName)
                || string.IsNullOrWhiteSpace(Name)
                || string.IsNullOrWhiteSpace(Password)
                || string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                NotAllFilledOut = true;
                return;
            }

            bool validEmail = Regex.IsMatch(Email, "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])");

            if (!validEmail)
            {
                EmailInvalid = true;
                return;
            }

            if (!Password.Equals(ConfirmPassword))
            {
                PasswordDoesntMatch = true;
                return;
            }

            var reader = OracleDatabase.ExecuteQuery(OracleDatabase.CreateCommand(
                $"""
                SELECT * FROM "USER"
                WHERE EMAIL = '{Email}'
                """))!;

            var users = reader.ToObjectList<User>();
            if (users.Any())
            {
                AccountTaken = true;
                return;
            }

            var commandText =
                $"""
                INSERT INTO "USER" (SALT, EMAIL, FIRST_NAME, NAME)
                VALUES (GENERATESALT, '{Email}', '{FirstName}', '{Name}')
                """;
            OracleDatabase.ExecuteNonQuery(OracleDatabase.CreateCommand(commandText));

            reader = OracleDatabase.ExecuteQuery(OracleDatabase.CreateCommand(
                $"""
                SELECT * FROM "USER"
                WHERE EMAIL = '{Email}'
                """))!;

            users = reader.ToObjectList<User>();
            if (!users.Any())
            {
                ErrorCreatingAcount = true;
                return;
            }

            var newUser = users[0];
            newUser.Password = PasswordUtil.Hash(Password, newUser.Salt);

            commandText =
                $"""
                UPDATE "USER"
                SET PASSWORD = '{newUser.Password}'
                WHERE EMAIL = '{Email}'
                """;

            OracleDatabase.ExecuteNonQuery(OracleDatabase.CreateCommand(commandText));

            await Application.Current!.MainPage!.Navigation.PopAsync();
        }
    }
}
