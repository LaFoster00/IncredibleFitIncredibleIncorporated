using IncredibleFit.IncredibleFit.ViewModels;

namespace IncredibleFit
{
    public partial class Login
    {
        public Login(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            this.BindingContext = loginViewModel;
        }
    }
}
