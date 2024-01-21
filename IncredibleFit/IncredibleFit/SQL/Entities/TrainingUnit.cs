using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("TRAINING UNIT")]
    public class TrainingUnit : BindableObject

    {
        [ID, Field("TRAININGUNITID", OracleDbType.Int32), ServerGenerated]
        public int TrainingUnitID
        {
            get => (int)GetValue(TrainingUnitIDProperty);
            private set => SetValue(TrainingUnitIDProperty, value);
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

        [Field("TRAININGUNITDIFFICULTY", OracleDbType.Int16)]
        public Difficulty TrainingUnitDifficulty
        {
            get => (Difficulty)GetValue(TrainingUnitDifficultyProperty);
            set => SetValue(TrainingUnitDifficultyProperty, value);
        }

        public static readonly BindableProperty TrainingUnitIDProperty =
            BindableProperty.Create(
                nameof(TrainingUnitID), 
                typeof(int), 
                typeof(TrainingUnit), 
                -1);

        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(
                nameof(Name), 
                typeof(string), 
                typeof(TrainingUnit), 
                string.Empty);

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create(
                nameof(Description), 
                typeof(string), 
                typeof(TrainingUnit), 
                string.Empty);

        public static readonly BindableProperty TrainingUnitDifficultyProperty =
            BindableProperty.Create(
                nameof(TrainingUnitDifficulty), 
                typeof(Difficulty), 
                typeof(TrainingUnit),
                Difficulty.Invalid);

        private TrainingUnit()
        {
        }

        public TrainingUnit(string name, string description, Difficulty difficulty)
        {
            this.Name = name;
            this.Description = description;
            this.TrainingUnitDifficulty = difficulty;
        }
    }
}
