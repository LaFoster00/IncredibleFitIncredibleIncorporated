// Written by Lisa Weickenmeier https://github.com/LisaWckn

using IncredibleFit.SQL.Entities;

namespace IncredibleFit.ContentViews;

public partial class TrainingPlanField : ContentView
{
    public TrainingPlan Plan
    {
        get => (TrainingPlan)GetValue(PlanProperty);
        set => SetValue(PlanProperty, value);
    }

    public static readonly BindableProperty PlanProperty = BindableProperty.Create(
            nameof(Plan),
            typeof(TrainingPlan),
            typeof(TrainingPlanField),
            null);

    public TrainingPlanField()
	{
		InitializeComponent();
	}
}