using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        protected bool _isBusy;
        [ObservableProperty]
        protected string? _title;
    }
}
