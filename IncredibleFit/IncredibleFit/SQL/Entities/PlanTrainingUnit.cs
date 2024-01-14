using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("PLANTRAININGUNIT")]
    public class PlanTrainingUnit
    {
        [ID, Field("PLANTRAININGUNITID", OracleDbType.Int32)]
        public int PlanTrainingUnitID { get; private set; } = -1;

        [Field("DESCRIPTION", OracleDbType.Varchar2, 1024)]
        public string Description { get; set; } = string.Empty;

        [Field("WEKKDAY", OracleDbType.Int16)]
        public Weekday Weekday { get; set; } = Weekday.FridayFridayGottaGetDownOnFriday;
        
        private PlanTrainingUnit() { }

        public PlanTrainingUnit(string description, Weekday weekday)
        {
            Description = description;
            Weekday = weekday;
        }
    }
}
