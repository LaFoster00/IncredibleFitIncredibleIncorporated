// Written by Lasse Foster https://github.com/LaFoster00

using IncredibleFit.ViewModels;

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
