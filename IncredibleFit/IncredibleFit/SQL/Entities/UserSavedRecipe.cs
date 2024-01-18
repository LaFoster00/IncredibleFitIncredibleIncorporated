using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.SQL.Entities
{
    [Entity("USER_SAVED_RECIPES")]
    public class UserSavedRecipe : BindableObject
    {
        [ID, Field("RECIPEID", OracleDbType.Int32)]
        public int RecipeID
        {
            get => (int)GetValue(RecipeIDProperty);
            set => SetValue(RecipeIDProperty, value);
        }

        [ID, Field("EMAIL", OracleDbType.Varchar2, 128)]
        public string Email
        {
            get => (string)GetValue(EmailProperty);
            set => SetValue(EmailProperty, value);
        }

        public static readonly BindableProperty RecipeIDProperty =
            BindableProperty.Create(
                nameof(RecipeID),
                typeof(int),
                typeof(UserSavedRecipe),
                -1);

        public static readonly BindableProperty EmailProperty =
            BindableProperty.Create(
                nameof(Email),
                typeof(string),
                typeof(UserSavedRecipe),
                string.Empty);

        private UserSavedRecipe() { }

        public UserSavedRecipe(int recipeID, string email)
        {
            RecipeID = recipeID;
            Email = email;
        }
    }
}
