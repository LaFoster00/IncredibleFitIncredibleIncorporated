using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("RECIPE")]
    public class Recipe
    {
        [ID, Field("RECIPEID", OracleDbType.Int64)] //Correct data type for serial?
        public int RecipeID { get; private set; } = 0;

        [Field("NAME", OracleDbType.Varchar2)]
        public string Name { get; set; } = string.Empty;

        [Field("DESCRIPTION", OracleDbType.Varchar2)]
        public string Description { get; set; } = string.Empty;

        [Field("INSTRUCTIONS", OracleDbType.Varchar2)]
        public string Instructions { get; set; } = string.Empty;

        [Field("VISIBILITY", OracleDbType.Varchar2)] //Domain in ERD ?
        public string Visibility { get; set; } = string.Empty;

        public int Energy { get; set; } = 0;

        public Recipe(string name, string description, string instructions, string visibility, int energy)
        {
            Name = name;
            Description = description;
            Instructions = instructions;
            Visibility = visibility;
            Energy = energy;
        }
    }
}
