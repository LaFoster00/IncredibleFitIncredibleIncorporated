using IncredibleFit.SQL.Entities;

namespace IncredibleFit.ContentViews;

public partial class TrainingPlanUnitField : ContentPage
{
    public PlanTrainingUnit Unit
    {
        get => (PlanTrainingUnit)GetValue(UnitProperty);
        set => SetValue(UnitProperty, value);
    }

    public static readonly BindableProperty UnitProperty = BindableProperty.Create(
            nameof(Unit),
            typeof(PlanTrainingUnit),
            typeof(TrainingPlanUnitField),
            null);

    public TrainingPlanUnitField()
	{
		InitializeComponent();
	}
}