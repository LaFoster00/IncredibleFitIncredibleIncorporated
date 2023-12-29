using IncredibleFit.Models;

namespace IncredibleFit.Screens;

public partial class DietPlan : ContentPage
{
    private Recipe nextRecipe = null;
	public DietPlan()
	{
		InitializeComponent();
	}

	void EditDietPlanClicked(object sender, EventArgs e)
	{

	}
    void RecipeClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RecipeDetails(nextRecipe));
    }
}