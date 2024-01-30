// Written by Lasse Foster https://github.com/LaFoster00

using IncredibleFit.ViewModels;

namespace IncredibleFit.Screens
{
    public partial class Login : ContentPage
    {
        public Login(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            this.BindingContext = loginViewModel;
        }
    }
}
