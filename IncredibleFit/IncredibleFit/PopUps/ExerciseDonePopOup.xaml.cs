using CommunityToolkit.Maui.Views;
using IncredibleFit.Models;
using IncredibleFit.Screens;

namespace IncredibleFit.PopUps;

public partial class ExerciseDonePopOup : Popup
{
	private Exercise _exercise;
	private Training _training;
	public ExerciseDonePopOup(Exercise ex, Training training)
	{
		InitializeComponent();
		_exercise = ex;
		_training = training;
	}

	void BtnYesClicked(object sender, EventArgs e)
	{
		_training.ExerciseDone(_exercise);
		this.Close();
    }

	void BtnNoClicked(object sender, EventArgs e)
	{
		this.Close();
	}
}