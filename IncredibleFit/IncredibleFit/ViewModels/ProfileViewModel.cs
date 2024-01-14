using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;

namespace IncredibleFit.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        private readonly SessionInfo _sessionInfo;

        [ObservableProperty] 
        private User? _currentUser;

        public ProfileViewModel(SessionInfo info)
        {
            _sessionInfo = info;
            CurrentUser = _sessionInfo.User;
            _sessionInfo.PropertyChanged += SessionInfoPropertyChanged;
            if (CurrentUser != null)
            {
                CurrentUser.PropertyChanged += CurrentUserOnPropertyChanged;
            }
        }

        private void SessionInfoPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SessionInfo.User):
                    if (CurrentUser != null)
                    {
                        CurrentUser.PropertyChanged -= CurrentUserOnPropertyChanged;
                    }

                    CurrentUser = _sessionInfo.User;

                    if (CurrentUser != null)
                    {
                        CurrentUser.PropertyChanged += CurrentUserOnPropertyChanged;
                    }
                    return;
            }
        }

        private void CurrentUserOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (IsActive)
                OracleDatabase.UpdateObject(CurrentUser);
        }
    }
}
