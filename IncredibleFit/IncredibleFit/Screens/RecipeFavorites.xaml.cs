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
        for (int i = 0; i < FavoritesList.Count; i++)
        {
            Recipecategory recipeCat = SQLNutrition.getRecipeCategory(FavoritesList[i]);
            FavoritesList[i].MealType = recipeCat.Mealtype;
            FavoritesList[i].FoodCategory = recipeCat.Foodcategory;
        }
        BindingContext = this;
    }

    void RecipeClicked(object sender, EventArgs e)
    {
        Grid grid = (Grid)sender;
        Label label = (Label)grid.Children[0];
        String name = label.Text;
        Recipe recipe = getRecipeByName(name);
        Navigation.PushAsync(new RecipeDetails(recipe, _sessionInfo));
    }

    Recipe getRecipeByName(string name)
    {
        Recipe recipe = null;
        for (int i = 0; i < FavoritesList.Count; i++)
        {
            if (FavoritesList[i].Name == name)
            {
                recipe = FavoritesList[i];
            }
        }
        return recipe;
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
}