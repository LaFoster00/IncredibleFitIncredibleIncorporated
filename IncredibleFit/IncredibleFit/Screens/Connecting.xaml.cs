using System.ComponentModel;
using IncredibleFit.SQL;

namespace IncredibleFit.Screens;

public partial class Connecting : ContentPage
{
	public Connecting()
	{
		InitializeComponent();
        BindingContext = OracleDatabase.Instance;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (OracleDatabase.Instance.Connected)
        {
            Shell.Current.GoToAsync("//Login");
            return;
        }
        OracleDatabase.Instance.PropertyChanged += DatabaseOnPropertyChanged;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        OracleDatabase.Instance.PropertyChanged -= DatabaseOnPropertyChanged;
    }

    private void DatabaseOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(OracleDatabase.Connected):
                Shell.Current.GoToAsync("//Login");
                return;
        }
    }
}