// Written by Lasse Foster https://github.com/LaFoster00

using CommunityToolkit.Mvvm.ComponentModel;

namespace IncredibleFit.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty] 
        private bool _isActive;
        [ObservableProperty]
        private bool _isBusy;
    }
}
