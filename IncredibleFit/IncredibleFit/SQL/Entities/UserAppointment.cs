// Written by Lisa Weickenmeier https://github.com/LisaWckn

using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("USER_APPOINTMENT")]
    internal class UserAppointment : BindableObject
    {
        [ID, Field("APPOINTMENTID", OracleDbType.Int32)]
        public int AppointmentID
        {
            get => (int)GetValue(AppointmentIDProperty);
            set => SetValue(AppointmentIDProperty, value);
        }

        [ID, Field("EMAIL", OracleDbType.Varchar2, 128)]
        public string Email
        {
            get => (string)GetValue(EmailProperty);
            set => SetValue(EmailProperty, value);
        }

        public static readonly BindableProperty AppointmentIDProperty =
            BindableProperty.Create(
                nameof(AppointmentID),
                typeof(int),
                typeof(UserAppointment),
                -1);

        public static readonly BindableProperty EmailProperty =
            BindableProperty.Create(
                nameof(Email),
                typeof(string),
                typeof(UserAppointment),
                string.Empty);

        private UserAppointment() { }

        public UserAppointment(int appointmentID, string email)
        {
            AppointmentID = appointmentID;
            Email = email;
        }
    }
}
