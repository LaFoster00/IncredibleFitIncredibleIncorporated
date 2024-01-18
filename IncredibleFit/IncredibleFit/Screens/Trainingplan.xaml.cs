using IncredibleFit.SQL.Entities;
using IncredibleFit.SQL;
using System.Collections.ObjectModel;

namespace IncredibleFit.Screens;

public partial class Trainingplan : ContentPage
{
	private SessionInfo _sessionInfo;
	private TrainingPlan _currentTrainingPlan;
	public ObservableCollection<PlanTrainingUnit> TrainingUnitArray { get; set; } = new ObservableCollection<PlanTrainingUnit>{ null, null, null, null, null, null, null };
	public Trainingplan(SessionInfo info)
	{
		_sessionInfo = info;
		_currentTrainingPlan = SQLTraining.getCurrentTrainingPlan(_sessionInfo.User!);
        List<PlanTrainingUnit> trainingUnits = SQLTraining.getTrainingUnitsByTrainingPlan(_currentTrainingPlan);

		for(int i = 0; i < trainingUnits.Count; i++)
		{
			if (trainingUnits[i].Weekday != Weekday.FridayFridayGottaGetDownOnFriday)
			{
				short weekday = (short)trainingUnits[i].Weekday;

                TrainingUnitArray[weekday] = trainingUnits[i];
            }
		}

		InitializeComponent();
		BindingContext = this;
	}
}