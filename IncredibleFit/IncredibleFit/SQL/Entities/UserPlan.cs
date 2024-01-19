using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("USER_PLAN")]
    public class UserPlan : BindableObject
    {
        [ID, Field("TRAININGPLANID", OracleDbType.Int32)]
        public int TrainingPlanID
        {
            get => (int)GetValue(TrainingPlanIDProperty);
            set => SetValue(TrainingPlanIDProperty, value);
        }

        [ID, Field("EMAIL", OracleDbType.Varchar2, 128)]
        public string Email
        {
            get => (string)GetValue(EmailProperty);
            set => SetValue(EmailProperty, value);
        }

        public static readonly BindableProperty TrainingPlanIDProperty =
            BindableProperty.Create(
                nameof(TrainingPlanID),
                typeof(int),
                typeof(UserPlan),
                -1);

        public static readonly BindableProperty EmailProperty =
            BindableProperty.Create(
                nameof(Email),
                typeof(string),
                typeof(UserPlan),
                string.Empty);

        private UserPlan() { }

        public UserPlan(int trainingPlanID, string email)
        {
            TrainingPlanID = trainingPlanID;
            Email = email;
        }
    }
}
