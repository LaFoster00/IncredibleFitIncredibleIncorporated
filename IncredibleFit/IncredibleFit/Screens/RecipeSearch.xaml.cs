using IncredibleFit.Models;
using IncredibleFit.SQL;
using System.Collections;
using System.Collections.ObjectModel;

namespace IncredibleFit.Screens;

public partial class RecipeSearch : ContentPage
{
	public ObservableCollection<Recipe> recipeList { get; set; } = SQLNutrition.getAllRecipes();
	public RecipeSearch()
	{
        InitializeComponent();
        BindingContext = this;
    }

    void RecipeClicked(object sender, EventArgs e)
	{
        Grid grid = (Grid)sender;
        Label label = (Label)grid.Children[0];
        String name = label.Text;
        Recipe recipe = getRecipeByName(name);
        Navigation.PushAsync(new RecipeDetails(recipe));
    }

    Recipe getRecipeByName(string name)
    {
        Recipe recipe = null;
        for (int i = 0; i < recipeList.Count; i++)
        {
            if (recipeList[i].Name == name)
            {
                recipe = recipeList[i];
            }
        }
        return recipe;
    }
}