// Written by Lisa Weickenmeier https://github.com/LisaWckn

using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace IncredibleFit.ContentViews;

public partial class TimeLineField : ContentView
{
	public DateTime DateTime
    {
        get => (DateTime)GetValue(DateTimeProperty);
        set
        {
            SetValue(DateTimeProperty, value);
            OnPropertyChanged(nameof(DateTime));
        }
    }

    public string Date
    {
        get => (string)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }

    public ObservableCollection<Appointment> Appointments
    {
        get => (ObservableCollection<Appointment>)GetValue(AppointmentsProperty);
        set => SetValue(AppointmentsProperty, value);
    }

    public bool AppointmentsVisible
    {
        get => (bool)GetValue(AppointmentsVisibleProperty);
        set => SetValue(AppointmentsVisibleProperty, value);
    }

    public bool AppointmentsNotVisible
    {
        get => (bool)GetValue(AppointmentsNotVisibleProperty);
        set => SetValue(AppointmentsNotVisibleProperty, value);
    }


    public static readonly BindableProperty DateTimeProperty = BindableProperty.Create(
            nameof(DateTime),
            typeof(DateTime),
            typeof(TimeLineField),
            DateTime.MinValue);

    public static readonly BindableProperty DateProperty = BindableProperty.Create(
            nameof(Date),
            typeof(string),
            typeof(TimeLineField),
            string.Empty);

    public static readonly BindableProperty AppointmentsProperty = BindableProperty.Create(
            nameof(Appointments),
            typeof(ObservableCollection<Appointment>),
            typeof(TimeLineField),
            new ObservableCollection<Appointment>());

    public static readonly BindableProperty AppointmentsVisibleProperty = BindableProperty.Create(
            nameof(AppointmentsVisible),
            typeof(bool),
            typeof(TimeLineField),
            true);

    public static readonly BindableProperty AppointmentsNotVisibleProperty = BindableProperty.Create(
            nameof(AppointmentsNotVisible),
            typeof(bool),
            typeof(TimeLineField),
            false);


    public TimeLineField()
    {
        InitializeComponent();
    }

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        switch (propertyName)
        {
            case nameof(DateTime):
                Date = DateTime.ToString("dd/MM/yyyy");
                SessionInfo info = SessionInfo.Instance;
                Appointments = SQLTimeline.getAllAppointmentsByDate(DateTime, info.User!);
                if (!Appointments.Any())
                {
                    AppointmentsVisible = false;
                    AppointmentsNotVisible = true;
                }
                break;
        }
    }

    void AppointmentClicked(object sender, EventArgs e)
	{

	}
}