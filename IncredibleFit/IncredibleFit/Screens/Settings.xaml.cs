using IncredibleFit.ViewModels;

namespace IncredibleFit.Screens;

public partial class Settings : ContentPage
{
	public Settings(SettingsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}