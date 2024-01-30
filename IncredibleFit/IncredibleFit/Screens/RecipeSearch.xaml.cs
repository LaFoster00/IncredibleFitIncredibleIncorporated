// Written by Lisa Weickenmeier https://github.com/LisaWckn

using IncredibleFit.SQL.Entities;
using IncredibleFit.PopUps;
using IncredibleFit.SQL;
using CommunityToolkit.Maui.Views;
using System.Collections;
using System.Collections.ObjectModel;

namespace IncredibleFit.Screens;

public partial class RecipeSearch : ContentPage
{
    private readonly SessionInfo _sessionInfo;
    private string _filterIngredient = "";
    private string _filterKeyword = "";
    public ObservableCollection<Recipe> recipeList { get; set; } = new ObservableCollection<Recipe>();
    public RecipeSearch(SessionInfo info)
	{
        InitializeComponent();
        _sessionInfo = info;
        recipeList = SQLNutrition.getAllVisibleRecipes(_sessionInfo.User!); ;
        
        BindingContext = this;
    }

    void RecipeClicked(object sender, EventArgs e)
	{
        ListView lV = (ListView)sender;
        Recipe recipe = (Recipe)lV.SelectedItem;
        Navigation.PushAsync(new RecipeDetails(recipe, _sessionInfo));
    }

    void AddFilterClicked(object sender, EventArgs e)
    {
        var popup = new EditRecipeSearchFilterPopUp(this, _filterKeyword,_filterIngredient);
        this.ShowPopup(popup);
    }

    void KeywordFilterClicked(object sender, EventArgs e)
    {
        this._filterKeyword = "";
        adjustFilters(_filterKeyword,_filterIngredient);
    }

    void IngredientFilterClicked(object sender, EventArgs e)
    {
        this._filterIngredient = "";
        adjustFilters(_filterKeyword, _filterIngredient);
    }

    public void adjustFilters(string filterKeyword, string filterIngredient)
    {
        this._filterKeyword = filterKeyword;
        this._filterIngredient = filterIngredient;
        recipeList.Clear();
        ObservableCollection<Recipe> recipeList2 = SQLNutrition.getRecipesByIngredientAndKeyword(filterKeyword, filterIngredient, _sessionInfo.User!);
        for (int i = 0; i < recipeList2.Count; i++)
        {
            recipeList.Add(recipeList2[i]);
        }
        adjustFilterVisibilityAndContent();
    }

    private void adjustFilterVisibilityAndContent()
    {
        bool bothFiltersActive = true;

        if (this._filterKeyword != "")
        {
            KeywordFilter.IsVisible = true;
            KeywordText.Text = "Keyword: " + this._filterKeyword;
        }
        else
        {
            bothFiltersActive = false;
            KeywordFilter.IsVisible = false;
        }

        if (this._filterIngredient != "")
        {
            IngredientFilter.IsVisible = true;
            IngredientText.Text = "Ingredient: " + this._filterIngredient;
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
}