using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("RECIPE")]
    public class Recipe : BindableObject
    {
        [ID, Field("RECIPEID", OracleDbType.Int32), ServerGenerated]
        public int RecipeID
        {
            get => (int)GetValue(RecipeIDProperty);
            private set => SetValue(RecipeIDProperty, value);
        }

        [Field("RECIPECATEGORYID", OracleDbType.Int32)]
        public int RecipeCategoryID
        {
            get => (int)GetValue(RecipeCategoryIDProperty);
            set => SetValue(RecipeCategoryIDProperty, value);
        }

        [Field("EMAIL", OracleDbType.Varchar2, 128)]
        public string Email
        {
            get => (string)GetValue(EmailProperty);
            set => SetValue(EmailProperty, value);
        }

        [Field("NAME", OracleDbType.Varchar2, 128)]
        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        [Field("DESCRIPTION", OracleDbType.Varchar2, 1024)]
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        [Field("INSTRUCTIONS", OracleDbType.Clob)]
        public string Instructions
        {
            get => (string)GetValue(InstructionsProperty);
            set => SetValue(InstructionsProperty, value);
        }

        [Field("VISIBILITY", OracleDbType.Int16)] //IDomain in ERD
        public Visibility Visibility
        {
            get => (Visibility)GetValue(VisibilityProperty);
            set => SetValue(VisibilityProperty, value);
        }

        public static readonly BindableProperty RecipeIDProperty =
            BindableProperty.Create(
                nameof(RecipeID), 
                typeof(int), 
                typeof(Recipe), 
                -1);

        public static readonly BindableProperty RecipeCategoryIDProperty =
            BindableProperty.Create(
                nameof(RecipeCategoryID),
                typeof(int),
                typeof(Recipe),
                -1);

        public static readonly BindableProperty EmailProperty =
            BindableProperty.Create(
                nameof(Email),
                typeof(string),
                typeof(Recipe),
                string.Empty);

        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(
                nameof(Name), 
                typeof(string), 
                typeof(Recipe), 
                string.Empty);

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create(
                nameof(Description), 
                typeof(string), 
                typeof(Recipe), 
                string.Empty);

        public static readonly BindableProperty InstructionsProperty =
            BindableProperty.Create(
                nameof(Instructions), 
                typeof(string), 
                typeof(Recipe), 
                string.Empty);

        public static readonly BindableProperty VisibilityProperty =
            BindableProperty.Create(
                nameof(Visibility), 
                typeof(Visibility), 
                typeof(Recipe), 
                (Visibility)Visibility.Invalid);

        public MealType MealType { get; set; } = MealType.Invalid;
        public FoodCategory FoodCategory { get; set; } = FoodCategory.Invalid;

        private Recipe() { }

        public Recipe(string name, string description, string instructions, Visibility visibility)
        {
            Name = name;
            Description = description;
            Instructions = instructions;
            Visibility = visibility;
        }
    }
}
