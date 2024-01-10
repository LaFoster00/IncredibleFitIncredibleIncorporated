using IncredibleFit.Models;

namespace IncredibleFit.Screens;

public partial class DietPlan : ContentPage
{
    private Recipe _nextRecipe = null;
	public DietPlan()
	{
		InitializeComponent();
	}

	void EditDietPlanClicked(object sender, EventArgs e)
	{

	}
    void RecipeClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RecipeDetails(_nextRecipe));
    }
}