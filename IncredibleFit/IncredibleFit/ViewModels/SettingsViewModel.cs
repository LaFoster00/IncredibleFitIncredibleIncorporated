using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using IncredibleFit.IncredibleFit.SQL;

namespace IncredibleFit.ViewModels
{
    public partial class SettingsViewModel : BaseViewModel
    {
        private readonly SessionInfo _info;
        private readonly LoginViewModel _loginViewModel;


        public SettingsViewModel(SessionInfo info, LoginViewModel loginViewModel)
        {
            this._info = info;
            _loginViewModel = loginViewModel;
        }

        [RelayCommand]
        public async Task Logout()
        {
            _info.User = null;
            _loginViewModel.ClearLogin();
            await Shell.Current.GoToAsync("//Login");
        }

        [RelayCommand]
        public async Task DeleteAccount()
        {
            SQLAccount.DeleteAccount(_info.User!);
            await Logout();
        }

    }
}
