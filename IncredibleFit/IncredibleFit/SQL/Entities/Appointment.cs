using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("APPOINTMENT")]
    public class Appointment : BindableObject
    {
        [ID, Field("APPOINTMENTID", OracleDbType.Int32), AutoIncrement]
        public int AppointmentID
        {
            get => (int)GetValue(AppointmentIDProperty);
            private set => SetValue(AppointmentIDProperty, value);
        }

        [Field("DATE", OracleDbType.Date)]
        public DateTime Date
        {
            get => (DateTime)GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }

        [Field("STATUS", OracleDbType.Int16)]
        public AppointmentStatus Status
        {
            get => (AppointmentStatus)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        public static readonly BindableProperty AppointmentIDProperty =
            BindableProperty.Create(
                nameof(AppointmentID), 
                typeof(int), 
                typeof(Appointment), 
                -1);

        public static readonly BindableProperty DateProperty =
            BindableProperty.Create(
                nameof(Date), 
                typeof(DateTime), 
                typeof(Appointment), 
                DateTime.MinValue);

        public static readonly BindableProperty StatusProperty =
            BindableProperty.Create(
                nameof(Status), 
                typeof(AppointmentStatus), 
                typeof(Appointment), 
                AppointmentStatus.Invalid);

        private Appointment() { }

        public Appointment(DateTime date, AppointmentStatus status)
        {
            Date = date;
            Status = status;
        }
    }
}
