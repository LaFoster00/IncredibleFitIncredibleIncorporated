using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("TRACK")]
    public class Track
    {
        [ID, Field("TRACKID", OracleDbType.Int32)]
        public int TrackID { get; private set; } = -1;

        [Field("DATE", OracleDbType.Date)]
        public DateTime Date { get; set;} = DateTime.MinValue;

        [Field("CALORIES", OracleDbType.Int16)]
        public Int16 Calories { get; set; } = -1;

        [Field("PROTEIN", OracleDbType.Int16)] 
        public Int16 Protein { get; set; } = -1;

        [Field("FAT", OracleDbType.Int16)]
        public Int16 Fat { get; set; } = -1;

        [Field("CARBONHYDRATES", OracleDbType.Int16)]
        public Int16 Carbonhydrates { get; set; } = -1;

        private Track() { }

        public Track(DateTime date, short calories, short protein, short fat, short carbonhydrates)
        {
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
