using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("APPOINTMENT")]
    public class Appointment
    {
        [ID, Field("APPOINTMENTID", OracleDbType.Int32)]
        public int AppointmentID { get; private set; } = -1;

        [Field("DATE", OracleDbType.Date)]
        public DateTime Date { get; set; } = DateTime.MinValue;

        [Field("STATUS", OracleDbType.Int16)]
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Invalid;

        private Appointment() { }

        public Appointment(DateTime date, AppointmentStatus status)
        {
            Date = date;
            Status = status;
        }
    }
}
