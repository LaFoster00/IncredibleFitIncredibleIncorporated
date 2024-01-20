using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;
using System.Runtime.CompilerServices;

namespace IncredibleFit.ContentViews;

public partial class AppointmentField : ContentView
{
	public Appointment Appointment
	{
        get => (Appointment)GetValue(AppointmentProperty);
        set => SetValue(AppointmentProperty, value);
    }

    public string Type
    {
        get => (string)GetValue(TypeProperty);
        set => SetValue(TypeProperty, value);
    }

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public static readonly BindableProperty AppointmentProperty = BindableProperty.Create(
            nameof(Appointment),
            typeof(Appointment),
            typeof(AppointmentField),
            null);

    public static readonly BindableProperty TypeProperty = BindableProperty.Create(
            nameof(Type),
            typeof(string),
            typeof(AppointmentField),
            string.Empty);

    public static readonly BindableProperty NameProperty = BindableProperty.Create(
            nameof(Name),
            typeof(string),
            typeof(AppointmentField),
            string.Empty);

    public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(
            nameof(Description),
            typeof(string),
            typeof(AppointmentField),
            string.Empty);

    public AppointmentField()
	{
		InitializeComponent();
	}

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        switch (propertyName)
        {
            case nameof(Appointment):
                
                if(Appointment.TrainingUnitID == -1)
                {
                    Recipe recipe = SQLTimeline.getRecipeByAppointment(Appointment);
                    if(recipe != null)
                    {
                        Type = "Recipe";
                        Name = recipe.Name; 
                        Description = recipe.Description;
                    }
                }
                else
                {
                    TrainingUnit trainingUnit = SQLTimeline.getTrainingUnitByAppointment(Appointment);
                    if(trainingUnit != null)
                    {
                        Type = "Training";
                        Name = trainingUnit.Name;
                        Description = trainingUnit.Description;
                    }
                }
                break;
        }
    }
}