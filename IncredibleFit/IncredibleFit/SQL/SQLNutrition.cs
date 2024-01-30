// Written by Lisa Weickenmeier https://github.com/LisaWckn

using IncredibleFit.SQL.Entities;
using MetalPerformanceShaders;
using Oracle.ManagedDataAccess.Client;
using System.Collections.ObjectModel;

namespace IncredibleFit.SQL
{
    public static class SQLNutrition
    {
        /// <summary>
        /// Retrieves a collection of recipes based on visibility criteria for a specific user from the database.
        /// The visibility of the recipe must either be public or it must be created by the user.
        /// </summary>
        /// <param name="user">The user for whom recipes are to be retrieved.</param>
        /// <returns>An ObservableCollection of Recipe objects based on visibility criteria.</returns>
        public static ObservableCollection<Recipe> getAllVisibleRecipes(User user)
        {
            ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();

            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "RECIPE"
                 WHERE VISIBILITY=1 OR (VISIBILITY = 0 AND EMAIL = '{user.Email}')
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Recipe>();

            return recipesWithCategorys(track);
        }

        /// <summary>
        /// Retrieves a collection of recipes based on keyword and ingredient criteria for a specific user from the database.
        /// </summary>
        /// <param name="keyword">The keyword to match against recipe names.</param>
        /// <param name="ingredientname">The ingredient name to filter recipes.</param>
        /// <param name="user">The user for whom recipes are to be retrieved.</param>
        /// <returns>
        /// An ObservableCollection of Recipe objects based on keyword and ingredient criteria.
        /// </returns>
        public static ObservableCollection<Recipe> getRecipesByIngredientAndKeyword(string keyword, string ingredientname, User user)
        {
            ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();

            var command = OracleDatabase.CreateCommand($""" """);

            if (ingredientname == "")
            {
                // If no ingredient name is provided, query for recipes based on the keyword and user email.
                command = OracleDatabase.CreateCommand(
                    $"""
                     SELECT * FROM "RECIPE"
                     WHERE (VISIBILITY=1 OR (VISIBILITY = 0 AND EMAIL = '{user.Email}')) AND NAME LIKE '%{keyword}%' 
                     """);
            }
            else
            {
                // If an ingredient name is provided, join with the "RECIPEINGREDIENT" table and filter by both keyword and ingredient.
                command = OracleDatabase.CreateCommand(
                    $"""
                     SELECT * FROM "RECIPE"
                     JOIN "RECIPEINGREDIENT"
                     ON RECIPEINGREDIENT.RECIPEID = RECIPE.RECIPEID
                     WHERE (RECIPE.VISIBILITY=1 OR (RECIPE.VISIBILITY = 0 AND RECIPE.EMAIL = '{user.Email}')) 
                     AND RECIPE.NAME LIKE '%{keyword}%' AND RECIPEINGREDIENT.INGREDIENTNAME = '{ingredientname}'
                     """);
            }

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Recipe>();

            return recipesWithCategorys(track);
        }

        /// <summary>
        /// Retrieves a collection of favorite recipes for a specific user from the database.
        /// </summary>
        /// <param name="user">The user for whom favorite recipes are to be retrieved.</param>
        /// <returns>
        /// An ObservableCollection of Recipe objects representing the favorite recipes of the user.
        /// </returns>
        public static ObservableCollection<Recipe> getFavoriteRecipes(User user)
        {
            ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();

            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT *
                 FROM "RECIPE"
                 WHERE "RECIPEID" IN (
                     SELECT "RECIPEID"
                     FROM "USER_SAVED_RECIPES"
                     WHERE "EMAIL" = '{user.Email}'
                 )
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Recipe>();

            return recipesWithCategorys(track);
        }

        /// <summary>
        /// Associates recipe category information with a collection of recipes.
        /// </summary>
        /// <param name="track">The list of recipes to associate with category information.</param>
        /// <returns>
        /// An ObservableCollection of Recipe objects with updated MealType and FoodCategory properties based on their associated recipe category.
        /// </returns>
        public static ObservableCollection<Recipe> recipesWithCategorys(List<Recipe>? track)
        {
            ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();

            if(track == null)
            {
                return recipes;
            }

            if (track.Any())
            {
                foreach (var item in track)
                {
                    Recipecategory? recipeCat = getRecipeCategory(item);
                    if (recipeCat != null)
                    {
                        item.MealType = recipeCat.Mealtype;
                        item.FoodCategory = recipeCat.Foodcategory;
                    }
                    recipes.Add(item);
                }
            }

            return recipes;
        }

        /// <summary>
        /// Retrieves the recipe category information for a specific recipe.
        /// </summary>
        /// <param name="recipe">The recipe for which to retrieve the category information.</param>
        /// <returns>
        /// A Recipecategory object representing the category information for the specified recipe,
        /// or null if no category information is found.
        /// </returns>
        public static Recipecategory? getRecipeCategory(Recipe recipe)
        {
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "RECIPECATEGORY" 
                 WHERE RECIPECATEGORYID = {recipe.RecipeCategoryID}
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Recipecategory>();

            return track.Any() ? track[0] : null;
        }

        /// <summary>
        /// Checks if a recipe is marked as a favorite by a specific user.
        /// </summary>
        /// <param name="recipe">The recipe to check for favorite status.</param>
        /// <param name="user">The user for whom the favorite status is checked.</param>
        /// <returns>
        /// Returns true if the recipe is marked as a favorite by the user; otherwise, returns false.
        /// </returns>
        public static bool isRecipeFavorite(Recipe recipe, User user)
        {
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "USER_SAVED_RECIPES"
                 WHERE EMAIL='{user.Email}' AND RECIPEID={recipe.RecipeID}
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<UserSavedRecipe>();
            return track.Any() ? true : false;
        }

        /// <summary>
        /// Adds a recipe to the list of favorites for a specific user.
        /// </summary>
        /// <param name="recipe">The recipe to be added to the favorites.</param>
        /// <param name="user">The user for whom the recipe is added to favorites.</param>
        public static void addToFavorites(Recipe recipe, User user)
        {
            UserSavedRecipe usR = new UserSavedRecipe(recipe.RecipeID, user.Email);
            OracleDatabase.InsertObject(usR);
        }

        /// <summary>
        /// Removes a recipe from the list of favorites for a specific user.
        /// </summary>
        /// <param name="recipe">The recipe to be removed from favorites.</param>
        /// <param name="user">The user for whom the recipe is removed from favorites.</param>
        public static void deleteFromFavorites(Recipe recipe, User user)
        {
            UserSavedRecipe usR = new UserSavedRecipe(recipe.RecipeID, user.Email);
            OracleDatabase.DeleteObject(usR);
        }

        /// <summary>
        /// Retrieves a collection of ingredients associated with a specific recipe.
        /// </summary>
        /// <param name="recipe">The recipe for which to retrieve the associated ingredients.</param>
        /// <returns>
        /// An ObservableCollection of Ingredient objects representing the ingredients associated with the specified recipe.
        /// </returns>
        public static ObservableCollection<Ingredient> getIngredientsByRecipe(Recipe recipe)
        {
            ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();

            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "INGREDIENT" 
                 JOIN "RECIPEINGREDIENT" 
                 ON RECIPEINGREDIENT.INGREDIENTNAME = INGREDIENT.INGREDIENTNAME
                 JOIN "RECIPE"
                 ON RECIPEINGREDIENT.RECIPEID = RECIPE.RECIPEID
                 WHERE RECIPE.RECIPEID = {recipe.RecipeID}
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Ingredient>();

            for (int i = 0; i < track.Count; i++)
            {
                ingredients.Add(track[i]);
            }

            return ingredients;
        }

        /// <summary>
        /// Retrieves the quantity of a specific ingredient used in a given recipe.
        /// </summary>
        /// <param name="recipe">The recipe in which to check the quantity of the ingredient.</param>
        /// <param name="ingredient">The ingredient for which to retrieve the quantity.</param>
        /// <returns>
        /// The quantity of the specified ingredient used in the given recipe, or 0 if the ingredient is not found.
        /// </returns>
        public static decimal getQuantityOfIngredient(Recipe recipe, Ingredient ingredient)
        {
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "RECIPEINGREDIENT" 
                 WHERE RECIPEID = {recipe.RecipeID} AND INGREDIENTNAME='{ingredient.IngredientName}'
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Recipeingredient>();

            return track.Any() ? track[0].Quantity : 0;
        }

        /// <summary>
        /// Retrieves the quantity unit associated with a specific ingredient.
        /// </summary>
        /// <param name="ingredient">The ingredient for which to retrieve the quantity unit.</param>
        /// <returns>
        /// The QuantityUnit enum representing the quantity unit associated with the specified ingredient,
        /// or QuantityUnit.Invalid if the ingredient is not found.
        /// </returns>
        public static QuantityUnit getQuantityUnitOfIngredient(Ingredient ingredient)
        {
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "QUANTITYPRICE" 
                 WHERE INGREDIENTNAME='{ingredient.IngredientName}'
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Quantityprice>();

            return track.Any() ? track[0].Quantityunit : QuantityUnit.Invalid;
        }

        /// <summary>
        /// Retrieves the user's track data for a specific date.
        /// </summary>
        /// <param name="date">The date for which to retrieve track data.</param>
        /// <param name="user">The user for whom track data is to be retrieved.</param>
        /// <returns>
        /// A Track object representing the user's track data for the specified date,
        /// or null if no track data is found for the given date and user.
        /// </returns>
        public static Track? getTrackByDate(DateTime date, User user)
        {
            DateTime date2 = new DateTime(date.Year, date.Month, date.Day);

            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "TRACK"
                 WHERE "DATE" = :PDATE AND EMAIL='{user.Email}'
                 """);
            command.Parameters.Add(new OracleParameter("PDATE", OracleDbType.Date)).Value = date2;

            var reader = OracleDatabase.ExecuteQuery(command);
            var track = reader.ToObjectList<Track>();

            return track.Any() ? track[0] : null;
        }

        /// <summary>
        /// Saves or updates a Calorie Track in the database for a specific date and user.
        /// </summary>
        /// <param name="calorieTrack">The Calorie Track object to be saved or updated.</param>
        public static void SaveCalorieTrack(Track calorieTrack)
        {
            DateTime date2 = new DateTime(calorieTrack.Date.Year, calorieTrack.Date.Month, calorieTrack.Date.Day);

            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM TRACK
                 WHERE "DATE" = :PDATE AND EMAIL = '{calorieTrack.Email}'
                 """);
            command.Parameters.Add(new OracleParameter("PDATE", OracleDbType.Date)).Value = date2;

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Track>();

            if (!track.Any())
            {
                OracleDatabase.InsertObject(calorieTrack);
            }
            else
            {
                OracleDatabase.UpdateObject(calorieTrack);
            }
        }
    }
}