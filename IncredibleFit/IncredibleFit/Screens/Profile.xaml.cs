using CommunityToolkit.Maui.Alerts;
using IncredibleFit.Models;
using IncredibleFit.SQL;

namespace IncredibleFit.Screens;

public partial class Profile : ContentPage
{
	private SQLProfile _sqlP = new SQLProfile();
	private User _currentUser = null;

    public Profile()
	{
		InitializeComponent();
		_currentUser = _sqlP.getUser();
		ChangeLabel();
	}

	public void ChangeLabel()
	{
        cardName.Text = _currentUser.Name;
		cardWeight.Text = _currentUser.Weight.ToString() + " kg";
		cardHeight.Text = _currentUser.Height.ToString() + " m";
		cardBodyFatPercentage.Text = _currentUser.BodyFatPercentage.ToString() + " %";
		cardFitnesslevel.Text = _currentUser.Fitnesslevel;
		cardAimDescription.Text = _currentUser.Aim.TargetDescription;
		cardAimWeight.Text = _currentUser.Aim.TargetWeight.ToString() + " kg";
    }

	void OnEditNameClicked(object sender, EventArgs e)
	{
		//TODO
		Toast.Make("Button clicked").Show();
	}
}