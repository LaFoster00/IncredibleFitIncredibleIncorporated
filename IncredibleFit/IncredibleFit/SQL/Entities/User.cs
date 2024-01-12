﻿using Oracle.ManagedDataAccess.Client;

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

        [Field("NAME", OracleDbType.Varchar2)]
        public string Name { get; set; } = string.Empty;

        [Field("FIRST_NAME", OracleDbType.Varchar2)]
        public string FirstName { get; set; } = string.Empty;

        [Field("WEIGHT", OracleDbType.Double)]
        public float? Weight { get; set; }

        [Field("HEIGHT", OracleDbType.Double)]
        public float? Height { get; set; }

        [Field("BODY_FAT_PERCENTAGE", OracleDbType.Double)]
        public float? BodyFatPercentage { get; set; }

        [Field("BASAL_METABOLIC_RATE", OracleDbType.Int64)]
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
