using CommunityToolkit.Maui.Views;
using IncredibleFit.PopUps;
using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;
using System.Collections;
using System.Collections.ObjectModel;

namespace IncredibleFit.Screens;

public partial class RecipeDetails : ContentPage
{
	private readonly SessionInfo _sessionInfo;
	private Recipe _recipe;
	private bool _isFavorite = false;
    public ObservableCollection<Ingredient> IngredientsList { get; set; } = new ObservableCollection<Ingredient> { };
    public RecipeDetails(Recipe recipe, SessionInfo info)
	{
		InitializeComponent();
        _sessionInfo = info;
        IngredientsList = SQLNutrition.getIngredientsByRecipe(recipe);

		for(int i = 0; i < IngredientsList.Count; i++)
		{
            IngredientsList[i].Quantity = SQLNutrition.getQuantityOfIngredient(recipe, IngredientsList[i]);
            IngredientsList[i].QuantityUnit = SQLNutrition.getQuantityUnitOfIngredient(IngredientsList[i]);

        }

		_isFavorite = SQLNutrition.isRecipeFavorite(recipe, _sessionInfo.User!);
		if(_isFavorite)
		{
			BtnHeart.Source = "icon_heart_filled.png";
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

		for (int i = 0;i< IngredientsList.Count;i++)
		{
			calories += IngredientsList[i].Calories;
			proteins += IngredientsList[i].Protein;
			fat += IngredientsList[i].Fat;
            carbonhydrates += IngredientsList[i].Carbonhydrates;
		}

        RecipeCalories.Text = calories.ToString();
        RecipeProteins.Text = proteins.ToString();
		RecipeFat.Text = fat.ToString();
        RecipeCarbonhydrates.Text = carbonhydrates.ToString();
    }

	void BtnHeartClicked(object sender, EventArgs e)
	{
		if (_isFavorite)
		{
			SQLNutrition.deleteFromFavorites(_recipe, _sessionInfo.User!);
            BtnHeart.Source = "icon_heart.png";
            _isFavorite = false;
		}
		else
		{
            SQLNutrition.addToFavorites(_recipe, _sessionInfo.User!);
            BtnHeart.Source = "icon_heart_filled.png";
            _isFavorite = true;
        }
	}

	void AddAppointmentClicked(object sender, EventArgs e)
	{
        var popup = new DatePickerPopUp(_recipe, _sessionInfo.User!);
        this.ShowPopup(popup);
    }

}