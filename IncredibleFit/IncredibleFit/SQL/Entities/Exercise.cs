using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("EXERCISE")]
    public class Exercise
    {
        [ID, Field("EXERCISEID", OracleDbType.Int32)]
        public int ExerciseID { get; private set; } = -1;

        [Field("NAME", OracleDbType.Varchar2, 128)]
        public string Name { get; set; } = string.Empty;

        [Field("DESCRIPTION", OracleDbType.Varchar2, 1024)]
        public string Description { get; set; } = string.Empty;

        [Field("EXERCISETYPE", OracleDbType.Int16)]
        public ExerciseType ExersiceType { get; set; } = ExerciseType.Invalid;

        private Exercise() { }

        public Exercise(string name, string description, short exerciseType) 
        {
            this.Name = name;
            this.Description = description;
            this.ExersiceType = exerciseType;
        }
    }
}
