using IncredibleFit.SQL.Entities;
using Microsoft.Maui.ApplicationModel.Communication;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Collections.ObjectModel;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IncredibleFit.SQL
{
    public static class SQLNutrition
    {
        public static ObservableCollection<Recipe> getAllVisibleRecipes()
        {
            ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();

            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "RECIPE"
                 WHERE VISIBILITY=1
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Recipe>();
            if (track.Any())
            {
                foreach ( var item in track)
                {
                    recipes.Add(item);
                }
            }

            return recipes;
        }

        public static ObservableCollection<Recipe> getRecipesByIngredientAndKeyword(string keyword, string ingredientname)
        {
            ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();

            var command = OracleDatabase.CreateCommand($""" """);

            if (ingredientname == "")
            {

                command = OracleDatabase.CreateCommand(
                    $"""
                 SELECT * FROM "RECIPE"
                 WHERE VISIBILITY=1 AND NAME LIKE '%{keyword}%' 
                 """);

            }
            else
            {
                command = OracleDatabase.CreateCommand(
                                    $"""
                 SELECT * FROM "RECIPE"
                 JOIN "RECIPEINGREDIENT"
                 ON RECIPEINGREDIENT.RECIPEID = RECIPE.RECIPEID
                 WHERE RECIPE.VISIBILITY=1 AND RECIPE.NAME LIKE '%{keyword}%' AND RECIPEINGREDIENT.INGREDIENTNAME = '{ingredientname}'
                 """);
            }

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Recipe>();
            if (track.Any())
            {
                foreach (var item in track)
                {
                    recipes.Add(item);
                }
            }

            return recipes;
        }

        public static ObservableCollection<Recipe> getFavoriteRecipes(User user)
        {
            ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();

            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "RECIPE" 
                 JOIN "USER_SAVED_RECIPES"
                 ON RECIPE.RECIPEID = USER_SAVED_RECIPES.RECIPEID
                 WHERE USER_SAVED_RECIPES.EMAIL='{user.Email}'
                 """);

            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Recipe>();
            if (track.Any())
            {
                foreach (var item in track)
                {
                    recipes.Add(item);
                }
            }

            return recipes;
        }

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
        public static void addToFavorites(Recipe recipe, User user)
        {
            UserSavedRecipe usR = new UserSavedRecipe(recipe.RecipeID, user.Email);
            OracleDatabase.InsertObject(usR);
        }

        public static void deleteFromFavorites(Recipe recipe, User user)
        {
            //TODO: All User Saved Recipes Elements with recipeID gets deleted. 
            UserSavedRecipe usR = new UserSavedRecipe(recipe.RecipeID, user.Email);
            OracleDatabase.DeleteObject(usR);
        }

        public static Recipecategory getRecipeCategory(Recipe recipe)
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

            for(int i=0; i < track.Count; i++)
            {
                ingredients.Add(track[i]);
            }

            return ingredients;
        }

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

        public static Track getTrackByDate(DateTime date, User? user)
        {
            string mail = "";
            if (user != null)
            {
                mail = user.Email;
            }
            DateTime date2 = new DateTime(date.Year, date.Month, date.Day);
            
            var command = OracleDatabase.CreateCommand(
                $"""
                 SELECT * FROM "TRACK"
                 WHERE "DATE" = :PDATE AND EMAIL='{mail}'
                 """);
            command.Parameters.Add(new OracleParameter("PDATE", OracleDbType.Date)).Value = date2;
            
            var reader = OracleDatabase.ExecuteQuery(command);

            var track = reader.ToObjectList<Track>();
            return track.Any() ? track[0] : null;
        }

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
            
            if(!track.Any()) 
            {
                OracleDatabase.InsertObject(calorieTrack);
            }
            else
            {
                OracleDatabase.UpdateObject(calorieTrack);
            }
        }

        public static void addRecipeAppointment(Recipe recipe, User user, DateTime date)
        {
            var command = OracleDatabase.CreateCommand(
                $"""
                 INSERT INTO APPOINTMENT("DATE", STATUS)
                 VALUES(:PDate, 0)
                 RETURNING APPOINTMENTID INTO :PappointmentID
                 """);
            command.Parameters.Add("PDate", OracleDbType.Date).Value = date;
            command.Parameters.Add("PappointmentID", OracleDbType.Int32).Direction = ParameterDirection.Output;

            OracleDatabase.ExecuteNonQuery(command);

            int appointmentID = (int)command.Parameters["PappointmentID"].Value.ToSystemObject(OracleDbType.Int32, typeof(int))!;


            //TODO
        }
    }
}