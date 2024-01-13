using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("RECIPECATEGORY")]
    public class Recipecategory
    {
        [ID, Field("RECIPECATEGORYID", OracleDbType.Int32)]
        public int RecipeCategoryID { get; private set; } = -1;

        [Field("MEALTYPE", OracleDbType.Int16)] //Domain in ERD
        public Int16 Mealtype { get; set; } = -1;

        [Field("FOODCATEGORY", OracleDbType.Int16)] //Domain in ERD
        public Int16 Foodcategory { get; set;} = -1;

        private Recipecategory() { }
        public Recipecategory(short mealtype, short foodcategory)
        {
            Mealtype = mealtype;
            Foodcategory = foodcategory;
        }
    }
}
