// Written by Lisa Weickenmeier https://github.com/LisaWckn

using IncredibleFit.SQL.Entities;

namespace IncredibleFit.ContentViews;

public partial class RecipeField : ContentView
{
	public Recipe Recipe
	{
        get => (Recipe)GetValue(RecipeProperty);
        set => SetValue(RecipeProperty, value);
    }

    public static readonly BindableProperty RecipeProperty = BindableProperty.Create(
            nameof(Recipe),
            typeof(Recipe),
            typeof(RecipeField),
            null);

    public RecipeField()
	{
		InitializeComponent();
	}
}