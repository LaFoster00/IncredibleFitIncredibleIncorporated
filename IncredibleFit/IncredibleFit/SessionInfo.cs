using CommunityToolkit.Mvvm.ComponentModel;
using IncredibleFit.SQL.Entities;

namespace IncredibleFit
{
    public partial class SessionInfo : ObservableObject
    {
        [ObservableProperty]
        private User? _user = null; 
    }
}
