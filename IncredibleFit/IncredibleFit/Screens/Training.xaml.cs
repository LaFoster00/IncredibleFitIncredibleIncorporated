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
		if(btn.Text == "Training starten")
		{
			btn.Text = "Training beenden";
            setStrokeAndTextColors(Color.FromArgb("#FB8505"), Colors.White);

        }
		else
		{
            btn.Text = "Training starten";
            setStrokeAndTextColors(Color.FromArgb("#00000000"), Color.FromArgb("#6E6E6E"));
            SQLTraining.setTrainingUnitDone(_nextTrainingUnit);
        }
	}

	void ExerciseDoneClicked(object sender, EventArgs e)
	{
        ListView lV = (ListView)sender;
        ExerciseUnit ex = (ExerciseUnit)lV.SelectedItem;
        if (BtnStartFinish.Text == "Training beenden" && !ex.IsFinished)
		{
            var popup = new ExerciseDonePopOup(ex, this);
			this.ShowPopup(popup);
		}
    }

	public void ExerciseDone(ExerciseUnit ex)
	{
        ExerciseUnits.Remove(ex);
		ex.IsFinished = true;
		ex.StrokeColor = Colors.Transparent;
		ex.TextColor = Color.FromArgb("#6E6E6E");
        ExerciseUnits.Add(ex);
		BindingContext = this;
    }


    private void setStrokeAndTextColors(Color strokeColor, Color textColor)
	{
		for(int i=0; i< ExerciseUnits.Count(); i++)
		{
			ExerciseUnit tmp = ExerciseUnits[i];	
			tmp.StrokeColor = strokeColor;
			tmp.TextColor = textColor;
			this.ExerciseUnits[i] = tmp;
		}
        BindingContext = this;
    }
}