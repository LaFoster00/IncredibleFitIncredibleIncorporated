using CommunityToolkit.Maui.Alerts;
using IncredibleFit.Models;
using IncredibleFit.SQL;

namespace IncredibleFit.Screens;

public partial class Profile : ContentPage
{
	SQLProfile sqlP = new SQLProfile();
	User currentUser = null;

    public Profile()
	{
		InitializeComponent();
		currentUser = sqlP.getUser();
		ChangeLabel();
	}

	public void ChangeLabel()
	{
        cardName.Text = currentUser.Name;
		cardWeight.Text = currentUser.Weight.ToString() + " kg";
		cardHeight.Text = currentUser.Height.ToString() + " m";
		cardBodyFatPercentage.Text = currentUser.BodyFatPercentage.ToString() + " %";
		cardFitnesslevel.Text = currentUser.Fitnesslevel;
		cardAimDescription.Text = currentUser.Aim.TargetDescription;
		cardAimWeight.Text = currentUser.Aim.TargetWeight.ToString() + " kg";
    }

	void OnEditNameClicked(object sender, EventArgs e)
	{
		//TODO
		Toast.Make("Button clicked").Show();
	}
}