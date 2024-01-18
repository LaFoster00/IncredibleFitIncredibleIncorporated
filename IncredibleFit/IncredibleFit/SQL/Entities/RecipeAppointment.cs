using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("RECIPE_APPOINTMENT")]
    internal class RecipeAppointment : BindableObject
    {
        [ID, Field("RECIPEID", OracleDbType.Int32)]
        public int RecipeID
        {
            get => (int)GetValue(RecipeIDProperty);
            private set => SetValue(RecipeIDProperty, value);
        }

        [Field("APPOINTMENTID", OracleDbType.Int32)]
        public int AppointmentID
        {
            get => (int)GetValue(AppointmentIDProperty);
            private set => SetValue(AppointmentIDProperty, value);
        }

        public static readonly BindableProperty RecipeIDProperty =
            BindableProperty.Create(
                nameof(RecipeID),
                typeof(int),
                typeof(RecipeAppointment),
                -1);

        public static readonly BindableProperty AppointmentIDProperty =
            BindableProperty.Create(
                nameof(AppointmentID),
                typeof(int),
                typeof(RecipeAppointment),
                -1);

        private RecipeAppointment() { }

        public RecipeAppointment(int recipeID, int appointmentID)
        {
            RecipeID = recipeID;
            AppointmentID = appointmentID;
        }
    }
}
