using IncredibleFit.Models;
using IncredibleFit.SQL;
using System.Collections.ObjectModel;

namespace IncredibleFit.Screens;

public partial class Trainingplan : ContentPage
{
    private SQLTraining _sqlTraining = new SQLTraining();
	private TrainingPlan _currentTrainingPlan = null;
    public ObservableCollection<TrainingPlanUnit> trainingUnits { get; set; } = new ObservableCollection<TrainingPlanUnit>();
	public Trainingplan()
	{
		_currentTrainingPlan = _sqlTraining.getCurrentTrainingPlan();
		for(int i = 0; i<_currentTrainingPlan.trainingUnits.Length; i++)
		{
			TrainingPlanUnit unit = _currentTrainingPlan.trainingUnits[i];
			if (unit.trainingUnit != null)
			{
				unit.exerciseCount = unit.trainingUnit.exercises.Count;
			}
			else
			{
				unit.exerciseCount = 0;
				unit.visibility = false;
				unit.trainingUnit = new TrainingUnit("Pause", "", "");
			}
			trainingUnits.Add(_currentTrainingPlan.trainingUnits[i]);
		}
		InitializeComponent();
		BindingContext = this;
	}
}