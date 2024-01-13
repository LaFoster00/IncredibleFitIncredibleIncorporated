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
            get => GetValue(EmailBindableProperty) as string;
            set => SetValue(EmailBindableProperty, value); }

        [Field("SALT", OracleDbType.Varchar2, 10), CreateWithSubroutine("GENERATESALT")]
        public string Salt
        {
            get => GetValue(SaltBindableProperty) as string;
            set => SetValue(SaltBindableProperty, value);
        }

        [Field("PASSWORD", OracleDbType.Varchar2, 128)]
        public string Password
        {
            get => GetValue(PasswordBindableProperty) as string;
            set => SetValue(PasswordBindableProperty, value);
        }

        [Field("LASTNAME", OracleDbType.Varchar2, 32)]
        public string Name
        {
            get => GetValue(NameBindableProperty) as string;
            set => SetValue(NameBindableProperty, value);
        }

        [Field("FIRSTNAME", OracleDbType.Varchar2, 32)]
        public string FirstName
        {
            get => GetValue(FirstNameBindableProperty) as string;
            set => SetValue(FirstNameBindableProperty, value);
        }

        [Field("WEIGHT", OracleDbType.Single)]
        public float? Weight
        {
            get => GetValue(WeightBindableProperty) as float?;
            set => SetValue(WeightBindableProperty, value);
        }

        [Field("HEIGHT", OracleDbType.Single)]
        public float? Height
        {
            get => GetValue(HeightBindableProperty) as float?;
            set => SetValue(HeightBindableProperty, value);
        }

        [Field("BODYFATPERCENTAGE", OracleDbType.Single)]
        public float? BodyFatPercentage
        {
            get => GetValue(BodyFatPercentageBindableProperty) as float?;
            set => SetValue(BodyFatPercentageBindableProperty, value);
        }

        [Field("BASALMETABOLICRATE", OracleDbType.Int32)]
        public int? BasalMetabolicRate
        {
            get => GetValue(BasalMetabolicRateBindableProperty) as int?;
            set => SetValue(BasalMetabolicRateBindableProperty, value);
        }

        [Field("TARGETDESCRIPTION", OracleDbType.Varchar2, 1024)]
        public string? TargetDescription
        {
            get => GetValue(TargetDescriptionBindableProperty) as string;
            set => SetValue(TargetDescriptionBindableProperty, value);
        }

        [Field("TARGETWEIGHT", OracleDbType.Single)]
        public float? TargetWeight
        {
            get => GetValue(TargetWeightBindableProperty) as float?;
            set => SetValue(TargetWeightBindableProperty, value);
        }

        public static readonly BindableProperty EmailBindableProperty = 
            BindableProperty.Create(
                nameof(Email),
                typeof(string), 
                typeof(User),
                string.Empty);

        public static readonly BindableProperty SaltBindableProperty =
            BindableProperty.Create(
                nameof(Salt),
                typeof(string),
                typeof(User),
                string.Empty);

        public static readonly BindableProperty PasswordBindableProperty =
            BindableProperty.Create(
                nameof(Password),
                typeof(string),
                typeof(User),
                string.Empty);

        public static readonly BindableProperty NameBindableProperty =
            BindableProperty.Create(
                nameof(Name),
                typeof(string),
                typeof(User),
                string.Empty);

        public static readonly BindableProperty FirstNameBindableProperty =
            BindableProperty.Create(
                nameof(FirstName),
                typeof(string),
                typeof(User),
                string.Empty);

        public static readonly BindableProperty WeightBindableProperty =
            BindableProperty.Create(
                nameof(Weight),
                typeof(float?),
                typeof(User),
                null);

        public static readonly BindableProperty HeightBindableProperty =
            BindableProperty.Create(
                nameof(Height),
                typeof(float?),
                typeof(User),
                null);

        public static readonly BindableProperty BodyFatPercentageBindableProperty =
            BindableProperty.Create(
                nameof(BodyFatPercentage),
                typeof(float?),
                typeof(User),
                null);

        public static readonly BindableProperty BasalMetabolicRateBindableProperty =
            BindableProperty.Create(
                nameof(BasalMetabolicRate),
                typeof(int?),
                typeof(User),
                null);

        public static readonly BindableProperty TargetDescriptionBindableProperty =
            BindableProperty.Create(
                nameof(TargetDescription),
                typeof(string),
                typeof(User),
                null);

        public static readonly BindableProperty TargetWeightBindableProperty =
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
