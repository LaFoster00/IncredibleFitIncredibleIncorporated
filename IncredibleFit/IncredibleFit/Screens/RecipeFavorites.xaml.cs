using IncredibleFit.SQL;
using IncredibleFit.SQL.Entities;
using System.Collections.ObjectModel;

namespace IncredibleFit.Screens;

public partial class RecipeFavorites : ContentPage
{
    private readonly SessionInfo _sessionInfo;
    public ObservableCollection<Recipe> FavoritesList { get; set; } = new ObservableCollection<Recipe>();
    public RecipeFavorites(SessionInfo info)
	{
		InitializeComponent();
        _sessionInfo = info;
        FavoritesList = SQLNutrition.getFavoriteRecipes(_sessionInfo.User!);
        
        BindingContext = this;
    }

    void RecipeClicked(object sender, EventArgs e)
    {
        ListView lV = (ListView)sender;
        Recipe recipe = (Recipe)lV.SelectedItem;
        Navigation.PushAsync(new RecipeDetails(recipe, _sessionInfo));
    }

    void RefreshFavorites(object sender, EventArgs e)
    {
        FavoritesList.Clear();
        ObservableCollection<Recipe> tmp = SQLNutrition.getFavoriteRecipes(_sessionInfo.User!);
        for (int i = 0; i < FavoritesList.Count; i++)
        {
            Recipecategory recipeCat = SQLNutrition.getRecipeCategory(tmp[i]);
            tmp[i].MealType = recipeCat.Mealtype;
            tmp[i].FoodCategory = recipeCat.Foodcategory;
        }

        for (int i = 0; i < tmp.Count; i++)
        {
            FavoritesList.Add(tmp[i]);
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        RefreshFavorites(null, null);
    }
}