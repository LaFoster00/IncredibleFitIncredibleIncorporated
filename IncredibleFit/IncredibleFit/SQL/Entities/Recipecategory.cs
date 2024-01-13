
using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("RECIPECATEGORY")]
    class Recipecategory
    {
        [ID, Field("RECIPECATEGORYID", OracleDbType.Int64)] //Correct data type for serial?
        public int RecipeCategoryID { get; private set; } = 0;

        [Field("MEALTYPE", OracleDbType.Varchar2)] //Domain in ERD
        public string Mealtype { get; set; } = string.Empty;

        [Field("FOODCATEGORY", OracleDbType.Varchar2)] //Domain in ERD
        public string Foodcategory { get; set;} = string.Empty;

        public Recipecategory(string mealtype, string foodcategory)
        {
            Mealtype = mealtype;
            Foodcategory = foodcategory;
        }
    }
}
