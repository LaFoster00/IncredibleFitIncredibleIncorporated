// Written by Lasse Foster https://github.com/LaFoster00 and Lisa Weikenmeier

using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("PLANTRAININGUNIT")]
    public class PlanTrainingUnit : BindableObject
    {
        [ID, Field("PLANTRAININGUNITID", OracleDbType.Int32), ServerGenerated]
        public int PlanTrainingUnitID
        {
            get => (int)GetValue(PlanTrainingUnitIDProperty);
            private set => SetValue(PlanTrainingUnitIDProperty, value);
        }

        [Field("DESCRIPTION", OracleDbType.Varchar2, 1024)]
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        [Field("WEEKDAY", OracleDbType.Int16)]
        public Weekday Weekday
        {
            get => (Weekday)GetValue(WeekdayProperty);
            set => SetValue(WeekdayProperty, value);
        }

        public static readonly BindableProperty PlanTrainingUnitIDProperty =
            BindableProperty.Create(
                nameof(PlanTrainingUnitID), 
                typeof(int), 
                typeof(PlanTrainingUnit), 
                -1);

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create(
                nameof(Description), 
                typeof(string), 
                typeof(PlanTrainingUnit), 
                string.Empty);

        public static readonly BindableProperty WeekdayProperty =
            BindableProperty.Create(
                nameof(Weekday), 
                typeof(Weekday), 
                typeof(PlanTrainingUnit), 
                Weekday.FridayFridayGottaGetDownOnFriday);

        private PlanTrainingUnit() { }

        public PlanTrainingUnit(string description, Weekday weekday)
        {
            Description = description;
            Weekday = weekday;
        }
    }
}
