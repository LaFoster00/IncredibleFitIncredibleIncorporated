using IncredibleFit.Models;
using IncredibleFit.PopUps;
using IncredibleFit.SQL;
using CommunityToolkit.Maui.Views;
using System.Collections;
using System.Collections.ObjectModel;

namespace IncredibleFit.Screens;

public partial class RecipeSearch : ContentPage
{
    private string _filterIngredient = "";
    private string _filterKeyword = "";
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

    void AddFilterClicked(object sender, EventArgs e)
    {
        var popup = new EditRecipeSearchFilterPopUp(this, _filterKeyword,_filterIngredient);
        this.ShowPopup(popup);
    }

    void KeywordFilterClicked(object sender, EventArgs e)
    {
        this._filterKeyword = "";
        adjustFilterVisibilityAndContent();
    }

    void IngredientFilterClicked(object sender, EventArgs e)
    {
        this._filterIngredient = "";
        adjustFilterVisibilityAndContent();
    }

    public void adjustFilters(string filterKeyword, string filterIngredient)
    {
        this._filterKeyword = filterKeyword;
        this._filterIngredient = filterIngredient;
        recipeList = SQLNutrition.getRecipesByIngredientAndKeyword(_filterKeyword, _filterIngredient);
        BindingContext = this;
        adjustFilterVisibilityAndContent();
    }

    private void adjustFilterVisibilityAndContent()
    {
        bool bothFiltersActive = true;

        if (this._filterKeyword != "")
        {
            KeywordFilter.IsVisible = true;
            KeywordText.Text = "Stichwort: " + this._filterKeyword;
        }
        else
        {
            bothFiltersActive = false;
            KeywordFilter.IsVisible = false;
        }

        if (this._filterIngredient != "")
        {
            IngredientFilter.IsVisible = true;
            IngredientText.Text = "Zutat: " + this._filterIngredient;
        }
        else
        {
            bothFiltersActive = false;
            IngredientFilter.IsVisible = false;
        }

        if (bothFiltersActive)
        {
            AddFilter.IsVisible = false;
        }
        else
        {
            AddFilter.IsVisible = true;
        }
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