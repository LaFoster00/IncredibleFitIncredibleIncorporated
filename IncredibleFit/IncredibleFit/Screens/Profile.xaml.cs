using CommunityToolkit.Maui.Alerts;

namespace IncredibleFit.Screens;

public partial class Profile : ContentPage
{
	private SessionInfo _sessionInfo;
    public Profile(SessionInfo info)
	{
		_sessionInfo = info;
		InitializeComponent();
		ChangeLabel();
	}

	public void ChangeLabel()
	{
        cardName.Text = _sessionInfo.User.Name;
		cardWeight.Text = _sessionInfo.User.Weight.ToString() + " kg";
		cardHeight.Text = _sessionInfo.User.Height.ToString() + " m";
		cardBodyFatPercentage.Text = _sessionInfo.User.BodyFatPercentage.ToString() + " %";
		//cardFitnesslevel.Text = _currentUser.Fitnesslevel;
		//cardAimDescription.Text = _currentUser.Aim.TargetDescription;
		//cardAimWeight.Text = _currentUser.Aim.TargetWeight.ToString() + " kg";
    }

	void OnEditNameClicked(object sender, EventArgs e)
	{
		//TODO
		Toast.Make("Button clicked").Show();
	}
}