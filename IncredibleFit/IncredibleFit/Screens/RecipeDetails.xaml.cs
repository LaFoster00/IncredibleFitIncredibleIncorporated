using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;
using System.Collections;
using System.Collections.ObjectModel;

namespace IncredibleFit.Screens;

public partial class RecipeDetails : ContentPage
{
	private SQLNutrition _sqlNutrition;
	private Recipe _recipe;
    public ObservableCollection<Ingredient> ingredientsList { get; set; } = new ObservableCollection<Ingredient> { };
    public RecipeDetails(Recipe recipe)
	{
		InitializeComponent();
		ingredientsList = _sqlNutrition.getIngredientsByRecipe(recipe);

        this._recipe = recipe;
		BindingContext = this;
		ChangeLabel();
	}

	private void ChangeLabel()
	{
        RecipeDetailsPage.Title = _recipe.Name;
        RecipeDescription.Text = _recipe.Description;
        RecipeInstructions.Text = _recipe.Instructions;
		RecipeEnergy.Text = _recipe.Energy.ToString();

		int? proteins = 0;
		int? fat = 0;
		int? carbonhydrates = 0;

		for (int i = 0;i< ingredientsList.Count;i++)
		{
			proteins += ingredientsList[i].Protein;
			fat += ingredientsList[i].Fat;
            carbonhydrates += ingredientsList[i].Carbonhydrates;
		}

        RecipeProteine.Text = proteins.ToString();
		RecipeFat.Text = fat.ToString();
		RecipeSugar.Text = carbonhydrates.ToString();
    }

}