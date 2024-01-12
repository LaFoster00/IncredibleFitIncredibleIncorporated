using CommunityToolkit.Maui.Views;
using IncredibleFit.IncredibleFit.Models;
using IncredibleFit.IncredibleFit.Screens;

namespace IncredibleFit.IncredibleFit.PopUps;

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