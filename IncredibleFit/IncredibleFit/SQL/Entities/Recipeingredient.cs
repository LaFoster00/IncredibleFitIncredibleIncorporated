using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("RECIPEINGREDIENT")]
    public class Recipeingredient : BindableObject
    {
        [ID, Field("RECIPEINGREDIENTID", OracleDbType.Int32), ServerGenerated]
        public int RecipeIngredientID
        {
            get => (int)GetValue(RecipeIngredientIDProperty);
            private set => SetValue(RecipeIngredientIDProperty, value);
        }

        [Field("QUANTITY", OracleDbType.Decimal)]
        public decimal Quantity
        {
            get => (decimal)GetValue(QuantityProperty);
            set => SetValue(QuantityProperty, value);
        }

        public static readonly BindableProperty RecipeIngredientIDProperty =
            BindableProperty.Create(
                nameof(RecipeIngredientID), 
                typeof(int), 
                typeof(Recipeingredient), 
                -1);

        public static readonly BindableProperty QuantityProperty =
            BindableProperty.Create(
                nameof(Quantity), 
                typeof(decimal), 
                typeof(Recipeingredient), 
                -1m);

        private Recipeingredient() { }

        public Recipeingredient(decimal quantity)
        {
            Quantity = quantity;
        }
    }
}
