using System.ComponentModel;
using System.Runtime.CompilerServices;
using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("USER")]
    public class User : BindableObject
    {
        [ID, Field("EMAIL", OracleDbType.Varchar2, 128)]
        public string Email { 
            get => (string)GetValue(EmailProperty);
            set => SetValue(EmailProperty, value); }

        [Field("SALT", OracleDbType.Varchar2, 10), CreateWithSubroutine("GENERATESALT")]
        public string Salt
        {
            get => (string)GetValue(SaltProperty);
            set => SetValue(SaltProperty, value);
        }

        [Field("PASSWORD", OracleDbType.Varchar2, 128)]
        public string Password
        {
            get => (string)GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }

        [Field("LASTNAME", OracleDbType.Varchar2, 32)]
        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        [Field("FIRSTNAME", OracleDbType.Varchar2, 32)]
        public string FirstName
        {
            get => (string)GetValue(FirstNameProperty);
            set => SetValue(FirstNameProperty, value);
        }

        [Field("WEIGHT", OracleDbType.Single)]
        public float? Weight
        {
            get => (float?)GetValue(WeightProperty);
            set => SetValue(WeightProperty, value);
        }

        [Field("HEIGHT", OracleDbType.Single)]
        public float? Height
        {
            get => (float?)GetValue(HeightProperty);
            set => SetValue(HeightProperty, value);
        }

        [Field("BODYFATPERCENTAGE", OracleDbType.Single)]
        public float? BodyFatPercentage
        {
            get => (float?)GetValue(BodyFatPercentageProperty);
            set => SetValue(BodyFatPercentageProperty, value);
        }

        [Field("BASALMETABOLICRATE", OracleDbType.Int32)]
        public int? BasalMetabolicRate
        {
            get => (int?)GetValue(BasalMetabolicRateProperty);
            set => SetValue(BasalMetabolicRateProperty, value);
        }

        [Field("TARGETDESCRIPTION", OracleDbType.Varchar2, 1024)]
        public string? TargetDescription
        {
            get => (string?)GetValue(TargetDescriptionProperty);
            set => SetValue(TargetDescriptionProperty, value);
        }

        [Field("TARGETWEIGHT", OracleDbType.Single)]
        public float? TargetWeight
        {
            get => (float?)GetValue(TargetWeightProperty);
            set => SetValue(TargetWeightProperty, value);
        }

        public static readonly BindableProperty EmailProperty = 
            BindableProperty.Create(
                nameof(Email),
                typeof(string), 
                typeof(User),
                string.Empty);

        public static readonly BindableProperty SaltProperty =
            BindableProperty.Create(
                nameof(Salt),
                typeof(string),
                typeof(User),
                string.Empty);

        public static readonly BindableProperty PasswordProperty =
            BindableProperty.Create(
                nameof(Password),
                typeof(string),
                typeof(User),
                string.Empty);

        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(
                nameof(Name),
                typeof(string),
                typeof(User),
                string.Empty);

        public static readonly BindableProperty FirstNameProperty =
            BindableProperty.Create(
                nameof(FirstName),
                typeof(string),
                typeof(User),
                string.Empty);

        public static readonly BindableProperty WeightProperty =
            BindableProperty.Create(
                nameof(Weight),
                typeof(float?),
                typeof(User),
                null);

        public static readonly BindableProperty HeightProperty =
            BindableProperty.Create(
                nameof(Height),
                typeof(float?),
                typeof(User),
                null);

        public static readonly BindableProperty BodyFatPercentageProperty =
            BindableProperty.Create(
                nameof(BodyFatPercentage),
                typeof(float?),
                typeof(User),
                null);

        public static readonly BindableProperty BasalMetabolicRateProperty =
            BindableProperty.Create(
                nameof(BasalMetabolicRate),
                typeof(int?),
                typeof(User),
                null);

        public static readonly BindableProperty TargetDescriptionProperty =
            BindableProperty.Create(
                nameof(TargetDescription),
                typeof(string),
                typeof(User),
                null);

        public static readonly BindableProperty TargetWeightProperty =
            BindableProperty.Create(
                nameof(TargetWeight),
                typeof(float?),
                typeof(User),
                null);

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

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
