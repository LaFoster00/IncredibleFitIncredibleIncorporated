using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("RECIPEINGREDIENT")]
    public class Recipeingredient
    {
        [ID, Field("RECIPEINGREDIENTID", OracleDbType.Int32)] 
        public int RecipeIngredientID { get; private set; } = -1;

        [Field("QUANTITY", OracleDbType.Decimal)]
        public decimal Quantity { get; set; } = -1;

        private Recipeingredient() { }

        public Recipeingredient(decimal quantity)
        {
            Quantity = quantity;
        }
    }
}
