using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;
using Microsoft.Maui;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace IncredibleFit.ContentViews;

public partial class TrainingPlanUnitField : ContentView
{
    public PlanTrainingUnit Unit
    {
        get => (PlanTrainingUnit)GetValue(UnitProperty);
        set => SetValue(UnitProperty, value);
    }

    public string WeekdayIndex
    {
        get => (string)GetValue(WeekdayIndexProperty);
        set => SetValue(WeekdayIndexProperty, value);
    }

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

    public static readonly BindableProperty WeekdayIndexProperty = BindableProperty.Create(
            nameof(WeekdayIndex),
            typeof(string),
            typeof(TrainingPlanUnitField),
            "-1");

    public static readonly BindableProperty VisibilityProperty = BindableProperty.Create(
            nameof(Visibility),
            typeof(bool),
            typeof(TrainingPlanUnitField),
            false);

    public TrainingPlanUnitField()
	{
		InitializeComponent();
	}

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        switch (propertyName)
        {
            case nameof(Unit):
                Visibility = true;
                TrainingUnit tU = SQLTraining.getTrainingUnit(Unit);
                Name.Text = tU.Name;
                Description.Text = tU.Description;
                TrainingUnitDifficulty.Text = tU.TrainingUnitDifficulty.ToString();
                int exerciseCount = SQLTraining.getExerciseCount(tU);
                ExerciseCount.Text = exerciseCount.ToString();
                break;
            case nameof(WeekdayIndex):
                short wIndex = short.Parse(WeekdayIndex.ToString());
                Weekday w = (Weekday)wIndex.ToDomain(Weekday.GetType())!;
                Weekday.Text = w.ToString();
                break;
        }
    }
}