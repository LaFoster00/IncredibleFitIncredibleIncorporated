using IncredibleFit.Models;
using IncredibleFit.PopUps;
using IncredibleFit.SQL;

namespace IncredibleFit.Screens;

using CommunityToolkit.Maui.Views;

public partial class CalorieTracker : ContentPage
{
    SQLProfile sqlP = new SQLProfile();
    User currentUser = null;
    public CalorieTracker()
	{
		InitializeComponent();
        currentUser = sqlP.getUser();
        ChangeLabel();
    }

    public void ChangeLabel()
    {
        UserBasalMetabolicRate.Text = currentUser.BasalMetabolicRate + " kcal";
    }

    void EditCaloriesClicked(object sender, EventArgs e)
    {
        ImageButton imgBtn = (ImageButton)sender;
        Grid grid = (Grid)imgBtn.Parent;
        int index = grid.GetRow(imgBtn);                //1=Mo, 2=Di, 3=Mi, ...
        var popup = new EditCaloriesPopUp();
        this.ShowPopup(popup);
    }
}