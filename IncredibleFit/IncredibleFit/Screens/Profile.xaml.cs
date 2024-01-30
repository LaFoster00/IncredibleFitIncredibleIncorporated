// Written by Lasse Foster https://github.com/LaFoster00

using IncredibleFit.ViewModels;

namespace IncredibleFit.Screens
{
	public partial class Profile : ContentPage
	{
        private readonly ProfileViewModel _viewModel;

		public Profile(ProfileViewModel viewModel)
		{
			InitializeComponent();
            _viewModel = viewModel;
            BindingContext = viewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.IsActive = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewModel.IsActive = false;
        }
    }
}