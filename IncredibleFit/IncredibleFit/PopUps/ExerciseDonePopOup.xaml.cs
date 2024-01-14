using CommunityToolkit.Maui.Views;
using IncredibleFit.SQL.Entities;
using IncredibleFit.Screens;

namespace IncredibleFit.PopUps;

public partial class ExerciseDonePopOup : Popup
{
	private ExerciseUnit _exerciseUnit;
	private Training _training;
	public ExerciseDonePopOup(ExerciseUnit ex, Training training)
	{
		InitializeComponent();
        _exerciseUnit = ex;
		_training = training;
	}

	void BtnYesClicked(object sender, EventArgs e)
	{
		_training.ExerciseDone(_exerciseUnit);
		this.Close();
    }

	void BtnNoClicked(object sender, EventArgs e)
	{
		this.Close();
	}
}