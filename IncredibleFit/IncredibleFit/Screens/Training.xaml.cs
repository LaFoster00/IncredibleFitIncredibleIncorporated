using System.Collections.ObjectModel;
using IncredibleFit.Models;
using IncredibleFit.PopUps;
using IncredibleFit.SQL;
using CommunityToolkit.Maui.Views;

namespace IncredibleFit.Screens;

public partial class Training : ContentPage
{
    private SQLTraining _sqlTraining = new SQLTraining();
    public ObservableCollection<Exercise> exercises { get; set; } = new ObservableCollection<Exercise>();

    private TrainingUnit _nextTrainingUnit = null;
    public Training()
    {
        InitializeComponent();
        _nextTrainingUnit = _sqlTraining.getNextTrainingUnit();
		for(int i=0; i<_nextTrainingUnit.exercises.Count; i++)
		{
			exercises.Add(_nextTrainingUnit.exercises[i]);
		}	
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
			_sqlTraining.setTrainingUnitDone(_nextTrainingUnit);
        }
	}

	void ExerciseDoneClicked(object sender, EventArgs e)
	{
        ListView lV = (ListView)sender;
        Exercise ex = (Exercise)lV.SelectedItem;
        if (BtnStartFinish.Text == "Training beenden" && !ex.isFinished)
		{
            var popup = new ExerciseDonePopOup(ex, this);
			this.ShowPopup(popup);
		}
    }

	public void ExerciseDone(Exercise ex)
	{
		exercises.Remove(ex);
		ex.isFinished = true;
		ex.strokeColor = Colors.Transparent;
		ex.textColor = Color.FromArgb("#6E6E6E");
		exercises.Add(ex);
		BindingContext = this;
    }


    private void setStrokeAndTextColors(Color strokeColor, Color textColor)
	{
		for(int i=0; i<exercises.Count(); i++)
		{
			Exercise tmp = exercises[i];	
			tmp.strokeColor = strokeColor;
			tmp.textColor = textColor;
			this.exercises[i] = tmp;
		}
        BindingContext = this;
    }
}