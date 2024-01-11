using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncredibleFit.SQL;

namespace IncredibleFit.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _firstName = string.Empty;

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _password = string.Empty;

        [ObservableProperty]
        private string _email = string.Empty;

        [ObservableProperty]
        private float? _weight = null;

        [ObservableProperty]
        private float? _height = null;

        [ObservableProperty]
        private float? _bodyFatPercentage = null;

        [ObservableProperty]
        private int? _basalMetabolicRate = null;

        private readonly SessionInfo _sessionInfo;

        public ProfileViewModel(SessionInfo info)
        {
            _sessionInfo = info;
            _sessionInfo.PropertyChanged += SessionInfoPropertyChanged;
            PopulateProperties();
            PropertyChanged += ProfileViewModel_PropertyChanged;
        }

        private void ProfileViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (_sessionInfo.User is null)
                return;

            switch (e.PropertyName)
            {
                case nameof(SessionInfo.User.FirstName):
                    _sessionInfo.User.FirstName = FirstName;
                    OracleDatabase.UpdateObject(_sessionInfo.User);
                    return;
                case nameof(SessionInfo.User.Name):
                    _sessionInfo.User.Name = Name;
                    OracleDatabase.UpdateObject(_sessionInfo.User);
                    return;
                case nameof(SessionInfo.User.Password):
                    _sessionInfo.User.Password = Password;
                    OracleDatabase.UpdateObject(_sessionInfo.User);
                    return;
                case nameof(SessionInfo.User.Weight):
                    _sessionInfo.User.Weight = Weight;
                    OracleDatabase.UpdateObject(_sessionInfo.User);
                    return;
                case nameof(SessionInfo.User.Height):
                    _sessionInfo.User.Height = Height;
                    OracleDatabase.UpdateObject(_sessionInfo.User);
                    return;
                case nameof(SessionInfo.User.BodyFatPercentage):
                    _sessionInfo.User.BodyFatPercentage = BodyFatPercentage;
                    OracleDatabase.UpdateObject(_sessionInfo.User);
                    return;
                case nameof(SessionInfo.User.BasalMetabolicRate):
                    _sessionInfo.User.BasalMetabolicRate = BasalMetabolicRate;
                    OracleDatabase.UpdateObject(_sessionInfo.User);
                    return;
            }
            throw new NotImplementedException();
        }

        private void SessionInfoPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SessionInfo.User))
            {
                PopulateProperties();
            }
        }

        private void PopulateProperties()
        {
            if (_sessionInfo.User != null)
            {
                FirstName = _sessionInfo.User.FirstName;
                Name = _sessionInfo.User.Name;
                Password = _sessionInfo.User.Password;
                Email = _sessionInfo.User.Email;
                Weight = _sessionInfo.User.Weight;
                Height = _sessionInfo.User.Height;
                BodyFatPercentage = _sessionInfo.User.BodyFatPercentage;
                BasalMetabolicRate = _sessionInfo.User.BasalMetabolicRate;
            }
            else
            {
                FirstName = "Undefined";
                FirstName = "Undefined";
                Name = "Undefined";
                Password = "Undefined";
                Email = "Undefined";
                Weight = -1;
                Height = -1;
                BodyFatPercentage = -1;
                BasalMetabolicRate = -1;
            }
        }
    }
}
