using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("RECIPECATEGORY")]
    public class Recipecategory
    {
        [ID, Field("RECIPECATEGORYID", OracleDbType.Int32)]
        public int RecipeCategoryID { get; private set; } = -1;

        [Field("MEALTYPE", OracleDbType.Int16)] //Domain in ERD
        public MealType Mealtype { get; set; } = MealType.Invalid;

        [Field("FOODCATEGORY", OracleDbType.Int16)] //Domain in ERD
        public FoodCategory Foodcategory { get; set;} = MealType.Invalid;

        private Recipecategory() { }
        public Recipecategory(short mealtype, short foodcategory)
        {
            Mealtype = mealtype;
            Foodcategory = foodcategory;
        }
    }
}
