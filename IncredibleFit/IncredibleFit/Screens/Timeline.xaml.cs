// Written by Lisa Weickenmeier https://github.com/LisaWckn

using System.Collections.ObjectModel;

namespace IncredibleFit.Screens;

public partial class Timeline : ContentPage
{ 
    public ObservableCollection<DateTime> dateTimes { get; set; } = new ObservableCollection<DateTime>();
	public Timeline(SessionInfo info)
	{
		InitializeComponent();
		DateTime now = DateTime.Now;
		dateTimes.Add(now);
		for(int i=1; i < 7; i++)
		{
			dateTimes.Add(now.AddDays(i));
		}
		BindingContext = this;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		InitializeComponent();
    }
}