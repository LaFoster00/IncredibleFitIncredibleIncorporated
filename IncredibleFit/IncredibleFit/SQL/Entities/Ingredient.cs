using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("INGREDIENT")]
    public class Ingredient : BindableObject
    {

        [ID, Field("INGREDIENTNAME", OracleDbType.Varchar2, 64)]
        public string IngredientName
        {
            get => (string)GetValue(IngredientNameProperty);
            set => SetValue(IngredientNameProperty, value);
        }

        [Field("FOODCATEGORY", OracleDbType.Int16)] //IDomain in ERD
        public FoodCategory Foodcategory
        {
            get => (FoodCategory)GetValue(FoodcategoryProperty);
            set => SetValue(FoodcategoryProperty, value);
        }

        [Field("CALORIES", OracleDbType.Int16)]
        public short Calories
        {
            get => (short)GetValue(CaloriesProperty);
            set => SetValue(CaloriesProperty, value);
        }

        [Field("PROTEIN", OracleDbType.Int16)]
        public short? Protein
        {
            get => (short?)GetValue(ProteinProperty);
            set => SetValue(ProteinProperty, value);
        }

        [Field("FAT", OracleDbType.Int16)]
        public short? Fat
        {
            get => (short?)GetValue(FatProperty);
            set => SetValue(FatProperty, value);
        }

        [Field("CARBONHYDRATES", OracleDbType.Int16)]
        public short? Carbonhydrates
        {
            get => (short?)GetValue(CarbonhydratesProperty);
            set => SetValue(CarbonhydratesProperty, value);
        }

        public static readonly BindableProperty IngredientNameProperty =
            BindableProperty.Create(
                nameof(IngredientName),
                typeof(string),
                typeof(Ingredient),
                string.Empty);

        public static readonly BindableProperty FoodcategoryProperty =
            BindableProperty.Create(
                nameof(Foodcategory), 
                typeof(FoodCategory), 
                typeof(Ingredient), 
                FoodCategory.Invalid);

        public static readonly BindableProperty CaloriesProperty =
            BindableProperty.Create(
                nameof(Calories), 
                typeof(short), 
                typeof(Ingredient), 
                (short)-1);

        public static readonly BindableProperty ProteinProperty =
            BindableProperty.Create(
                nameof(Protein), 
                typeof(short?), 
                typeof(Ingredient),
                null);

        public static readonly BindableProperty FatProperty =
            BindableProperty.Create(
                nameof(Fat), 
                typeof(short?), 
                typeof(Ingredient), 
                null);

        public static readonly BindableProperty CarbonhydratesProperty =
            BindableProperty.Create(nameof(Carbonhydrates), typeof(short?), typeof(Ingredient), (short?)0);

        private Ingredient() { }

        public Ingredient(string ingredientName, FoodCategory foodcategory, short calories, short? protein, short? fat, short? carbonhydrates)
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
