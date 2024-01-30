// Written by Lasse Foster https://github.com/LaFoster00

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