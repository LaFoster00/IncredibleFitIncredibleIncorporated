using IncredibleFit.SQL.Entities;

namespace IncredibleFit.ContentViews;

public partial class TrainingPlanUnitField : ContentView
{
    public PlanTrainingUnit Unit
    {
        get => (PlanTrainingUnit)GetValue(UnitProperty);
        set => SetValue(UnitProperty, value);
    }

    /*public int Weekday
    {
        get => (int)GetValue(WeekdayProperty);
        set => SetValue(WeekdayProperty, value);
    }*/

    public bool Visibility
    {
        get => (bool)GetValue(VisibilityProperty);
        set => SetValue(VisibilityProperty, value);
    }

    public static readonly BindableProperty UnitProperty = BindableProperty.Create(
            nameof(Unit),
            typeof(PlanTrainingUnit),
            typeof(TrainingPlanUnitField),
            null);

    /*public static readonly BindableProperty WeekdayProperty = BindableProperty.Create(
            nameof(Weekday),
            typeof(int),
            typeof(TrainingPlanUnitField),
            -1);*/

    public static readonly BindableProperty VisibilityProperty = BindableProperty.Create(
            nameof(Visibility),
            typeof(bool),
            typeof(TrainingPlanUnitField),
            false);

    public TrainingPlanUnitField()
	{
		InitializeComponent();
	}

    private void showValues()
    {
        //Weekday.Text = Unit.Weekday.ToString();
    }
}