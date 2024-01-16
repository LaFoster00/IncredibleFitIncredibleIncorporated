using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("TRACK")]
    public class Track : BindableObject
    {
        [ID, Field("TRACKID", OracleDbType.Int32), AutoIncrement]
        public int TrackID
        {
            get => (int)GetValue(TrackIDProperty);
            private set => SetValue(TrackIDProperty, value);
        }

        [Field("EMAIL", OracleDbType.Varchar2, 128)]
        public string Email
        {
            get => (string)GetValue(EmailProperty);
            set => SetValue(EmailProperty, value);
        }

        [Field("DATE", OracleDbType.Date)]
        public DateTime Date
        {
            get => (DateTime)GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }

        [Field("CALORIES", OracleDbType.Int16)]
        public short Calories
        {
            get => (short)GetValue(CaloriesProperty);
            set => SetValue(CaloriesProperty, value);
        }

        [Field("PROTEIN", OracleDbType.Int16)]
        public short Protein
        {
            get => (short)GetValue(ProteinProperty);
            set => SetValue(ProteinProperty, value);
        }

        [Field("FAT", OracleDbType.Int16)]
        public short Fat
        {
            get => (short)GetValue(FatProperty);
            set => SetValue(FatProperty, value);
        }

        [Field("CARBONHYDRATES", OracleDbType.Int16)]
        public short Carbonhydrates
        {
            get => (short)GetValue(CarbonhydratesProperty);
            set => SetValue(CarbonhydratesProperty, value);
        }

        public static readonly BindableProperty TrackIDProperty =
            BindableProperty.Create(
                nameof(TrackID), 
                typeof(int), 
                typeof(Track), 
                -1);

        public static readonly BindableProperty EmailProperty =
            BindableProperty.Create(
                nameof(Email),
                typeof(string),
                typeof(Track),
                string.Empty);

        public static readonly BindableProperty DateProperty =
            BindableProperty.Create(
                nameof(Date), 
                typeof(DateTime), 
                typeof(Track), 
                DateTime.MinValue);

        public static readonly BindableProperty CaloriesProperty =
            BindableProperty.Create(
                nameof(Calories), 
                typeof(short), 
                typeof(Track), 
                (short)-1);

        public static readonly BindableProperty ProteinProperty =
            BindableProperty.Create(
                nameof(Protein), 
                typeof(short), 
                typeof(Track), 
                (short)-1);

        public static readonly BindableProperty FatProperty =
            BindableProperty.Create(
                nameof(Fat), 
                typeof(short), 
                typeof(Track), 
                (short)-1);

        public static readonly BindableProperty CarbonhydratesProperty =
            BindableProperty.Create(
                nameof(Carbonhydrates), 
                typeof(short), 
                typeof(Track), 
                (short)-1);

        public string Weekday { get; set; } = "";

        private Track() { }

        public Track(string email, DateTime date, short calories, short protein, short fat, short carbonhydrates)
        {
            Email = email;
            Date = date;
            Calories = calories;
            Protein = protein;
            Fat = fat;
            Carbonhydrates = carbonhydrates;
        }

        public override bool Equals(object? obj)
        {
            return obj is Track track &&
                   Date == track.Date &&
                   Calories == track.Calories &&
                   Protein == track.Protein &&
                   Fat == track.Fat &&
                   Carbonhydrates == track.Carbonhydrates;
        }
    }
}
