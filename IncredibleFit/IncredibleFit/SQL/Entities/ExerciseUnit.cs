using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("EXERCISEUNIT")]
    public class ExerciseUnit
    {
        [ID, Field("EXERCISEUNITID", OracleDbType.Int32)]
        public int ExerciseUnitID { get; private set; } = -1;

        [Field("DESCRIPTION", OracleDbType.Varchar2, 1024)]
        public string Description { get; set; } = string.Empty;

        [Field("EXERCISEDIFFICULTY", OracleDbType.Int16)]
        public Difficulty ExerciseDifficulty { get; set; } = Difficulty.Invalid;

        [Field("REPETITIONS", OracleDbType.Int16)]
        public Int16 Repetitions { get; set; } = -1;

        public Color StrokeColor { get; set; } = Color.FromArgb("#00000000");
        public Color TextColor { get; set; } = Color.FromArgb("#6E6E6E");

        public bool IsFinished { get; set; } = false;

        private ExerciseUnit() { }

        public ExerciseUnit(string description, Difficulty exerciseDifficulty, short repetitions)
        {
            Description = description;
            ExerciseDifficulty = exerciseDifficulty;
            Repetitions = repetitions;
        }
    }
}
