using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("USER")]
    public class User
    {
        [ID, Field("EMAIL", OracleDbType.Varchar2)]
        public string Email { get; set; } = string.Empty;

        [Field("SALT", OracleDbType.Varchar2, 10), CreateWithSubroutine("GENERATESALT")]
        public string Salt { get; private set; } = string.Empty;

        [Field("PASSWORD", OracleDbType.Varchar2)]
        public string Password { get; set; } = string.Empty;

        [Field("LASTNAME", OracleDbType.Varchar2)]
        public string Name { get; set; } = string.Empty;

        [Field("FIRSTNAME", OracleDbType.Varchar2)]
        public string FirstName { get; set; } = string.Empty;

        [Field("WEIGHT", OracleDbType.Single)]
        public float? Weight { get; set; }

        [Field("HEIGHT", OracleDbType.Single)]
        public float? Height { get; set; }

        [Field("BODYFATPERCENTAGE", OracleDbType.Single)]
        public float? BodyFatPercentage { get; set; }

        [Field("BASALMETABOLICRATE", OracleDbType.Int64)]
        public int? BasalMetabolicRate { get; set; }

        private User() {}

        public User(string email, string name, string firstName, float? weight = null, float? height = null, float? bodyFatPercentage = null, int? basalMetabolicRate = null)
        {
            Email = email;
            Name = name;
            FirstName = firstName;
            Weight = weight;
            Height = height;
            BodyFatPercentage = bodyFatPercentage;
            BasalMetabolicRate = basalMetabolicRate;
        }
    }
}
