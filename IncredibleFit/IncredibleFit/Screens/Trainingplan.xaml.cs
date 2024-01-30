// Written by Lisa Weickenmeier https://github.com/LisaWckn

using IncredibleFit.SQL.Entities;
using IncredibleFit.SQL;
using System.Collections.ObjectModel;

namespace IncredibleFit.Screens;

public partial class Trainingplan : ContentPage
{
	private SessionInfo _sessionInfo;
	private TrainingPlan? _currentTrainingPlan;
	public ObservableCollection<PlanTrainingUnit?> TrainingUnitArray { get; set; } = new ObservableCollection<PlanTrainingUnit?>{ null, null, null, null, null, null, null };
	public Trainingplan(SessionInfo info)
	{
		_sessionInfo = info;
        _currentTrainingPlan = SQLTraining.getCurrentTrainingPlan(_sessionInfo.User!);
        refreshTrainingPlan();

		InitializeComponent();
		BindingContext = this;
	}

	void BtnEditPlanClicked(object sender, EventArgs e)
	{
        Navigation.PushAsync(new SelectTrainingplan(_sessionInfo, this));
    }

	public void refreshTrainingPlan()
	{
        _currentTrainingPlan = SQLTraining.getCurrentTrainingPlan(_sessionInfo.User!);

        if (_currentTrainingPlan == null) { return; }

        TrainingUnitArray = new ObservableCollection<PlanTrainingUnit?> { null, null, null, null, null, null, null };

        List<PlanTrainingUnit>? trainingUnits = SQLTraining.getPlanTrainingUnitsByTrainingPlan(_currentTrainingPlan);

        if(trainingUnits == null) { return; }

        for (int i = 0; i < trainingUnits.Count; i++)
        {
            if (trainingUnits[i].Weekday != Weekday.Invalid)
            {
                short weekday = (short)trainingUnits[i].Weekday;

                TrainingUnitArray[weekday] = trainingUnits[i];
            }
        }

        BindingContext = this;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        refreshTrainingPlan();
        InitializeComponent();
    }
}