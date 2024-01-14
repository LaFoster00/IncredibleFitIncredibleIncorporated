using IncredibleFit.SQL.Entities;
using IncredibleFit.SQL;
using System.Collections.ObjectModel;

namespace IncredibleFit.Screens;

public partial class Trainingplan : ContentPage
{
	private TrainingPlan _currentTrainingPlan = SQLTraining.getCurrentTrainingPlan();
    public ObservableCollection<PlanTrainingUnit> trainingUnits { get; set; } = new ObservableCollection<PlanTrainingUnit>();
	public Trainingplan()
	{
		trainingUnits = SQLTraining.getTrainingUnitsByTrainingPlan(_currentTrainingPlan);

        /*for (int i = 0; i<trainingUnits.Count; i++)
		{
			PlanTrainingUnit unit = _currentTrainingPlan.trainingUnits[i];
			if (trainingUnits[i] != null)
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
		}*/

		InitializeComponent();
		BindingContext = this;
	}
}