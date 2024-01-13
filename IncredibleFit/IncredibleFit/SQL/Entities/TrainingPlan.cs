using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("TRAININGPLAN")]
    public class TrainingPlan
    {
        [ID, Field("TRAININGPLANID", OracleDbType.Int32)]
        public int TrainingPlanID { get; private set; } = -1;

        [Field("NAME", OracleDbType.Varchar2, 128)]
        public string Name { get; set; } = string.Empty;

        [Field("DESCRIPTION", OracleDbType.Varchar2, 1024)]
        public string Description { get; set; } = string.Empty;

        [Field("TRAININGPLANDIFFICULTY", OracleDbType.Int16)]
        public Difficulty TrainingPlanDifficulty { get; set; } = Difficulty.Invalid;

        private TrainingPlan() { }

        public TrainingPlan(string name, string description, Difficulty trainingPlanDifficulty)
        {
            Name = name;
            Description = description;
            TrainingPlanDifficulty = trainingPlanDifficulty;
        }
    }
}
