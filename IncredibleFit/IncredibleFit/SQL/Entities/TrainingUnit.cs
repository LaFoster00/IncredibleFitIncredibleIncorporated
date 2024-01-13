using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("TRAINING UNIT")]
    public class TrainingUnit
    {
        [ID, Field("TRAININGUNITID", OracleDbType.Int32)]
        public int TrainingUnitID { get; private set; } = -1;

        [Field("NAME", OracleDbType.Varchar2, 128)]
        public string Name { get; set; } = string.Empty;

        [Field("DESCRIPTION", OracleDbType.Varchar2, 1024)]
        public string Description { get; set; } = string.Empty;

        [Field("TRAININGUNITDIFFICULTY", OracleDbType.Int16)]
        public Difficulty TrainingUnitDifficulty { get; set; } = Difficulty.Invalid;

        private TrainingUnit() { }

        public TrainingUnit(string name, string description, short difficulty)
        {
            this.Name = name;
            this.Description = description;
            this.TrainingUnitDifficulty = difficulty;
        }
    }
}
