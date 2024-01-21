using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("TRAININGPLAN")]
    public class TrainingPlan : BindableObject
    {
        [ID, Field("TRAININGPLANID", OracleDbType.Int32), ServerGenerated]
        public int TrainingPlanID
        {
            get => (int)GetValue(TrainingPlanIDProperty);
            private set => SetValue(TrainingPlanIDProperty, value);
        }

        [Field("NAME", OracleDbType.Varchar2, 128)]
        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        [Field("SPORTNAME", OracleDbType.Varchar2, 128)]
        public string Sportname
        {
            get => (string)GetValue(SportnameProperty);
            set => SetValue(SportnameProperty, value);
        }

        [Field("DESCRIPTION", OracleDbType.Varchar2, 1024)]
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        [Field("TRAININGPLANDIFFICULTY", OracleDbType.Int16)]
        public Difficulty TrainingPlanDifficulty
        {
            get => (Difficulty)GetValue(TrainingPlanDifficultyProperty);
            set => SetValue(TrainingPlanDifficultyProperty, value);
        }

        public static readonly BindableProperty TrainingPlanIDProperty =
            BindableProperty.Create(
                nameof(TrainingPlanID), 
                typeof(int), 
                typeof(TrainingPlan), 
                -1);

        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(
                nameof(Name), 
                typeof(string), 
                typeof(TrainingPlan), 
                string.Empty);

        public static readonly BindableProperty SportnameProperty =
            BindableProperty.Create(
                nameof(Sportname),
                typeof(string),
                typeof(TrainingPlan),
                string.Empty);

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create(
                nameof(Description), 
                typeof(string), 
                typeof(TrainingPlan), 
                string.Empty);

        public static readonly BindableProperty TrainingPlanDifficultyProperty =
            BindableProperty.Create(
                nameof(TrainingPlanDifficulty), 
                typeof(Difficulty), 
                typeof(TrainingPlan), 
                Difficulty.Invalid);

        private TrainingPlan() { }

        public TrainingPlan(string name, string sportname, string description, Difficulty trainingPlanDifficulty)
        {
            Name = name;
            Sportname = sportname;
            Description = description;
            TrainingPlanDifficulty = trainingPlanDifficulty;
        }
    }
}
