using CommunityToolkit.Maui.Alerts;
using IncredibleFit.ViewModels;

namespace IncredibleFit.Screens
{
	public partial class Profile : ContentPage
	{
		private SessionInfo _sessionInfo;
		public Profile(SessionInfo info, ProfileViewModel viewModel)
		{
			InitializeComponent();
			_sessionInfo = info;
			BindingContext = viewModel;
		}
	}
}