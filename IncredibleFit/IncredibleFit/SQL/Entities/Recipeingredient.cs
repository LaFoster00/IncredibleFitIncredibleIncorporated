using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("RECIPEINGRIDIENT")] //Need to correct typo later
    class Recipeingredient
    {
        [ID, Field("RECIPEINGRIDIENTID", OracleDbType.Int64)] //Correct data type for serial? Correct typo later
        public int RecipeIngridientID { get; private set; } = 0;

        [Field("QUANTITY", OracleDbType.Int64)] //Number in ERD
        public int Quantity { get; set; } = 0; 
    }
}
