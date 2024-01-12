using IncredibleFit.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.Screens
{
    public partial class SignUp : ContentPage
    {
        public SignUp(SignUpViewModel signUpViewModel)
        {
            InitializeComponent();
            BindingContext = signUpViewModel;
            Appearing += (sender, args) => signUpViewModel.Reset(true);
        }
    }
}
