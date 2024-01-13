using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("RECIPE")]
    public class Recipe
    {
        [ID, Field("RECIPEID", OracleDbType.Int32)] //Correct data type for serial?
        public int RecipeID { get; private set; } = -1;

        [Field("NAME", OracleDbType.Varchar2, 128)]
        public string Name { get; set; } = string.Empty;

        [Field("DESCRIPTION", OracleDbType.Varchar2, 1024)]
        public string Description { get; set; } = string.Empty;

        [Field("INSTRUCTIONS", OracleDbType.Clob)]
        public string Instructions { get; set; } = string.Empty;

        [Field("VISIBILITY", OracleDbType.Int16)] //Domain in ERD
        public Int16 Visibility { get; set; } = -1;

        public int Calories { get; set; } = 0;

        private Recipe() { }

        public Recipe(string name, string description, string instructions, short visibility, int calories)
        {
            Name = name;
            Description = description;
            Instructions = instructions;
            Visibility = visibility;
            Calories = calories;
        }
    }
}
