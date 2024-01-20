using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;
using System.Collections.ObjectModel;

namespace IncredibleFit.Screens;

public partial class SelectTrainingplan : ContentPage
{
	private SessionInfo _sessionInfo;
	private Trainingplan _trainingplan;
	public ObservableCollection<TrainingPlan> TrainingPlans { get; set; } = new ObservableCollection<TrainingPlan>();

    public SelectTrainingplan(SessionInfo info, Trainingplan trainingplan)
	{
		InitializeComponent();
		_sessionInfo = info;
		_trainingplan = trainingplan;
		TrainingPlans = SQLTraining.getAllTrainingPlans();
		BindingContext = this;
	}

	void TrainingplanSelected(object sender, EventArgs e)
	{
		SQLTraining.deleteCurrentTrainingplan(_sessionInfo.User!);
        ListView lV = (ListView)sender;
        TrainingPlan traingPlan = (TrainingPlan)lV.SelectedItem;
        SQLTraining.setNewTrainingplan(traingPlan, _sessionInfo.User!);

		_trainingplan.refreshTrainingPlan();
        Shell.Current.Navigation.RemovePage(this);
    }
}