using IncredibleFit.Models;
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
		this._recipe = recipe;
		for (int i = 0; i < recipe.Ingredients.Count; i++)
		{
			ingredientsList.Add(recipe.Ingredients[i]);
		}
		BindingContext = this;
		ChangeLabel();
	}

	private void ChangeLabel()
	{
        RecipeDetailsPage.Title = _recipe.Name;
        RecipeDescription.Text = _recipe.Description;
        RecipeInstructions.Text = _recipe.Instructions;
		RecipeEnergy.Text = _recipe.Energy.ToString();

		double proteins = 0;
		double fat = 0;
		double roughage = 0;
		double water = 0;

		for (int i = 0;i<_recipe.Ingredients.Count;i++)
		{
			proteins += _recipe.Ingredients[i].Proteincontent;
			fat += _recipe.Ingredients[i].Fatcontent;
			roughage += _recipe.Ingredients[i].Roughagecontent;
			water += _recipe.Ingredients[i].Watercontent;
		}

        RecipeProteine.Text = Math.Round(proteins, 2).ToString();
		RecipeFat.Text = Math.Round(fat, 2).ToString();
		RecipeSugar.Text = Math.Round(roughage, 2).ToString();
		RecipeWater.Text = Math.Round(water, 2).ToString();
    }

}