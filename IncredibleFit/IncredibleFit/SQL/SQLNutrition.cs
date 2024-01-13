using IncredibleFit.SQL.Entities;
using System.Collections.ObjectModel;

namespace IncredibleFit.SQL
{
    public static class SQLNutrition
    {
        public static ObservableCollection<Recipe> getAllRecipes()
        {
            ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();

            //get all Recipes from Database

            recipes = getDummyRecipes();

            return recipes;
        }

        public static ObservableCollection<Recipe> getRecipesByIngredientAndKeyword(string keyword, string ingredient)
        {
            //TODO Get Recipes from Database

            return getDummyRecipes();
        }

        public static ObservableCollection<Ingredient> getIngredientsByRecipe(Recipe recipe)
        {
            ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
            //TODO Get Ingredients from Database
            return ingredients;
        }

        public static void SaveCalorieTrack(Track calorieTrack)
        {
            //TODO Save calorieTrack in Database
        }


        private static ObservableCollection<Recipe> getDummyRecipes()
        {
            ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();

            /*recipes.Add(new Recipe("Lasagne", "Leckerer Auflauf mit Nudeln und Hackfleisch", "Bla", 1, "Fleischhaltig", 100, new List<Ingredient> { }));
            recipes.Add(new Recipe("Pfannkuchen", "Nach Wunsch belegte Teigfladen", "Bla", 1, "Vegetarisch", 50, new List<Ingredient> { }));
            List<Ingredient> ingredients = new List<Ingredient> { };
            ingredients.Add(new Ingredient("Zucchini", 1, 17.0, 1.2, 0.3, 1.5, 95.0, new Quantityprice(0, 400, 0.5, 1.0)));
            ingredients.Add(new Ingredient("Aubergine", 1, 25, 1, 0.2, 3.5, 92, new Quantityprice(0, 300, 1, 2)));
            ingredients.Add(new Ingredient("Paprika", 1, 31, 1, 0.3, 4.2, 92, new Quantityprice(0, 300, 0.7, 1.5)));
            ingredients.Add(new Ingredient("Tomate", 1, 18, 0.9, 0.2, 2.6, 94, new Quantityprice(0, 400, 0.3, 0.6)));
            ingredients.Add(new Ingredient("Knoblauchzehe", 1, 149, 6.4, 0.5, 1, 58, new Quantityprice(0, 20, 0.2, 0.4)));
            ingredients.Add(new Ingredient("Olivenöl", 1, 884, 0, 100, 0, 0, new Quantityprice(1, 30, 0.3, 0.6)));
            ingredients.Add(new Ingredient("Kräuter", 1, 0, 0, 0, 0, 0, new Quantityprice(0, 10, 0.5, 1.5)));
            int wholeEnergy = 0;
            for (int i = 0; i < ingredients.Count; i++)
            {
                wholeEnergy += (int)ingredients[i].Energy;
            }
            recipes.Add(new Recipe("Knuspriges Gemüse-Ratatouille",
                "Ein herzhaftes Gericht, das die Aromen verschiedener Gemüsesorten in einer knusprigen, würzigen und köstlichen Kombination vereint.",
                "Vorbereitungszeit: 20 Minuten\nKochzeit: 40 Minuten\nGesamtdauer: 60 Minuten\nPortionen: 4\n\nOfen auf 180°C vorheizen. Zucchini, Aubergine, Paprika und Tomaten in gleichmäßige Scheiben schneiden. Gemüsescheiben auf einem Backblech verteilen, Knoblauch darüber streuen und mit Olivenöl beträufeln. Mit den Kräutern bestreuen und für 40 Minuten im Ofen backen, bis das Gemüse knusprig und goldbraun ist. Aus dem Ofen nehmen und heiß servieren.",
                1, "Vegetarisch", wholeEnergy, ingredients));*/

            return recipes;
        }
    }
}