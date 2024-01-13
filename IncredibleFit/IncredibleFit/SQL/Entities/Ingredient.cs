using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("INGREDIENT")]
    public class Ingredient
    {
        [ID, Field("INGREDIENTNAME", OracleDbType.Varchar2)]
        public string IngredientName { get; private set; } = String.Empty;

        [Field("FOODCATEGORY", OracleDbType.Varchar2)] //Domain in ERD
        public string Foodcategory { get; set; } = String.Empty;

        [Field("CALORIES", OracleDbType.Int64)]
        public int Calories { get; set; } = 0;

        [Field("PROTEIN", OracleDbType.Int64)]
        public int? Protein { get; set; } = 0;

        [Field("FAT", OracleDbType.Int64)]
        public int Fat { get; set; } = 0;

        [Field("CARBONHYDRATES", OracleDbType.Int64)]
        public int Carbonhydrates { get; set; } = 0;

        public Ingredient(string ingredientName, string foodcategory, int calories, int? protein, int fat, int carbonhydrates)
        {
            IngredientName = ingredientName;
            Foodcategory = foodcategory;
            Calories = calories;
            Protein = protein;
            Fat = fat;
            Carbonhydrates = carbonhydrates;
        }
    }
}
