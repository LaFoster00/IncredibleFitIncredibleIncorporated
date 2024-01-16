using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("EXERCISE")]
    public class Exercise : BindableObject
    {
        [ID, Field("EXERCISEID", OracleDbType.Int32), AutoIncrement]
        public int ExerciseID
        {
            get => (int)GetValue(ExerciseIDProperty);
            private set => SetValue(ExerciseIDProperty, value);
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

        [Field("EXERCISETYPE", OracleDbType.Int16)]
        public ExerciseType ExersiceType
        {
            get => (ExerciseType)GetValue(ExerciseTypeProperty);
            set => SetValue(ExerciseTypeProperty, value);
        }

        public static readonly BindableProperty ExerciseIDProperty =
            BindableProperty.Create(
                nameof(ExerciseID), 
                typeof(int), 
                typeof(Exercise), 
                -1);

        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(
                nameof(Name), 
                typeof(string), 
                typeof(Exercise), 
                string.Empty);

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create(
                nameof(Description), 
                typeof(string), 
                typeof(Exercise), 
                string.Empty);

        public static readonly BindableProperty ExerciseTypeProperty =
            BindableProperty.Create(
                nameof(ExersiceType), 
                typeof(ExerciseType), 
                typeof(Exercise), 
                ExerciseType.Invalid);

        private Exercise() { }

        public Exercise(string name, string description, short exerciseType) 
        {
            this.Name = name;
            this.Description = description;
            this.ExersiceType = exerciseType;
        }
    }
}
