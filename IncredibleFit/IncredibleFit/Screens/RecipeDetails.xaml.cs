using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;
using System.Collections;
using System.Collections.ObjectModel;

namespace IncredibleFit.Screens;

public partial class RecipeDetails : ContentPage
{
	private Recipe _recipe;
    public ObservableCollection<Ingredient> ingredientsList { get; set; } = new ObservableCollection<Ingredient> { };
    public RecipeDetails(Recipe recipe)
	{
		InitializeComponent();
		ingredientsList = SQLNutrition.getIngredientsByRecipe(recipe);

		for(int i = 0; i < ingredientsList.Count; i++)
		{
            ingredientsList[i].Quantity = SQLNutrition.getQuantityOfIngredient(recipe, ingredientsList[i]);
			ingredientsList[i].QuantityUnit = SQLNutrition.getQuantityUnitOfIngredient(ingredientsList[i]);

        }

        this._recipe = recipe;
		BindingContext = this;
		ChangeLabel();
	}

	private void ChangeLabel()
	{
        RecipeDetailsPage.Title = _recipe.Name;
        RecipeDescription.Text = _recipe.Description;
        RecipeInstructions.Text = _recipe.Instructions;

		int? calories = 0;
		int? proteins = 0;
		int? fat = 0;
		int? carbonhydrates = 0;

		for (int i = 0;i< ingredientsList.Count;i++)
		{
			calories += ingredientsList[i].Calories;
			proteins += ingredientsList[i].Protein;
			fat += ingredientsList[i].Fat;
            carbonhydrates += ingredientsList[i].Carbonhydrates;
		}

        RecipeCalories.Text = calories.ToString();
        RecipeProteins.Text = proteins.ToString();
		RecipeFat.Text = fat.ToString();
        RecipeCarbonhydrates.Text = carbonhydrates.ToString();
    }

}