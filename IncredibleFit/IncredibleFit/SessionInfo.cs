using CommunityToolkit.Mvvm.ComponentModel;
using IncredibleFit.IncredibleFit.SQL.Entities;

namespace IncredibleFit.IncredibleFit
{
    public partial class SessionInfo : ObservableObject
    {
        [ObservableProperty]
        private User? _user; 
    }
}
