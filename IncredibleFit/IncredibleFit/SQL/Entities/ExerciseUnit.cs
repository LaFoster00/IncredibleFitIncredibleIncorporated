using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("EXERCISEUNIT")]
    public class ExerciseUnit : BindableObject
    {
        [ID, Field("EXERCISEUNITID", OracleDbType.Int32), ServerGenerated]
        public int ExerciseUnitID
        {
            get => (int)GetValue(ExerciseUnitIDProperty);
            private set => SetValue(ExerciseUnitIDProperty, value);
        }

        [Field("EXERCISEID", OracleDbType.Int32), ServerGenerated]
        public int ExerciseID
        {
            get => (int)GetValue(ExerciseIDProperty);
            set => SetValue(ExerciseIDProperty, value);
        }

        [Field("DESCRIPTION", OracleDbType.Varchar2, 1024)]
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        [Field("EXERCISEDIFFICULTY", OracleDbType.Int16)]
        public Difficulty ExerciseDifficulty
        {
            get => (Difficulty)GetValue(ExerciseDifficultyProperty);
            set => SetValue(ExerciseDifficultyProperty, value);
        }

        [Field("REPETITIONS", OracleDbType.Int16)]
        public short Repetitions
        {
            get => (short)GetValue(RepetitionsProperty);
            set => SetValue(RepetitionsProperty, value);
        }

        public static readonly BindableProperty ExerciseUnitIDProperty =
            BindableProperty.Create(
                nameof(ExerciseUnitID), 
                typeof(int), 
                typeof(ExerciseUnit), 
                -1);

        public static readonly BindableProperty ExerciseIDProperty =
            BindableProperty.Create(
                nameof(ExerciseID),
                typeof(int),
                typeof(ExerciseUnit),
                -1);

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create(
                nameof(Description), 
                typeof(string), 
                typeof(ExerciseUnit), 
                string.Empty);

        public static readonly BindableProperty ExerciseDifficultyProperty =
            BindableProperty.Create(
                nameof(ExerciseDifficulty), 
                typeof(Difficulty), 
                typeof(ExerciseUnit), 
                Difficulty.Invalid);

        public static readonly BindableProperty RepetitionsProperty =
            BindableProperty.Create(
                nameof(Repetitions), 
                typeof(short), 
                typeof(ExerciseUnit), 
                (short)-1);

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
