using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("INGREDIENT")]
    public class Ingredient
    {
        [ID, Field("INGREDIENTNAME", OracleDbType.Varchar2 ,64)]
        public string IngredientName { get; set; } = String.Empty;

        [Field("FOODCATEGORY", OracleDbType.Int16)] //Domain in ERD
        public FoodCategory Foodcategory { get; set; } = FoodCategory.Invalid;

        [Field("CALORIES", OracleDbType.Int16)]
        public Int16 Calories { get; set; } = -1;

        [Field("PROTEIN", OracleDbType.Int16)]
        public Int16? Protein { get; set; } = 0;

        [Field("FAT", OracleDbType.Int16)]
        public Int16? Fat { get; set; } = 0;

        [Field("CARBONHYDRATES", OracleDbType.Int16)]
        public Int16? Carbonhydrates { get; set; } = 0;

        private Ingredient() { }

        public Ingredient(string ingredientName, short foodcategory, short calories, short? protein, short? fat, short? carbonhydrates)
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
