// Written by Lasse Foster https://github.com/LaFoster00

using CommunityToolkit.Mvvm.ComponentModel;
using IncredibleFit.SQL.Entities;

namespace IncredibleFit
{
    public partial class SessionInfo : ObservableObject
    {
        public static SessionInfo Instance { get; private set; }

        public SessionInfo()
        {
            Instance = this;
        }

        [ObservableProperty]
        private User? _user = null; 
    }
}
