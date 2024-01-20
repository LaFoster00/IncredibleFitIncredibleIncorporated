using System.Collections.ObjectModel;
using IncredibleFit.SQL.Entities;
using IncredibleFit.PopUps;
using IncredibleFit.SQL;
using CommunityToolkit.Maui.Views;

namespace IncredibleFit.Screens;

public partial class Training : ContentPage
{
	private SessionInfo _sessionInfo;
    public ObservableCollection<ExerciseUnit> ExerciseUnits { get; set; } = new ObservableCollection<ExerciseUnit>();

    private TrainingUnit _nextTrainingUnit;
    public Training(SessionInfo info)
    {
        InitializeComponent();
		_sessionInfo = info;
        _nextTrainingUnit = SQLTraining.getNextTrainingUnit(_sessionInfo.User!);
        ExerciseUnits = SQLTraining.getExerciseUnits(_nextTrainingUnit);
        BindingContext = this;
    }

	void BtnStartFinishClicked(object sender, EventArgs e)
	{
		Button btn = (Button)sender;
		if(btn.Text == "Start training")
		{
			btn.Text = "End training";

        }
		else
		{
            btn.Text = "Start training";
            SQLTraining.setTrainingUnitDone(_nextTrainingUnit);

            ExerciseUnits.Clear();
            _nextTrainingUnit = SQLTraining.getNextTrainingUnit(_sessionInfo.User!);
            ExerciseUnits = SQLTraining.getExerciseUnits(_nextTrainingUnit);
            BindingContext = this;
        }
	}
}