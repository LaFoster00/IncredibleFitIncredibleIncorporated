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

        public SettingsViewModel(SessionInfo info)
        {
            this._info = info;
        }

        [RelayCommand]
        public async Task Logout()
        {
            _info.User = null;
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
