using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("TRACK")]
    public class Track
    {
        [ID, Field("TRACKID", OracleDbType.Int64)] //correct type for serial?
        public int TrackID { get; private set; } = 0;

        [Field("DATE", OracleDbType.TimeStamp)]
        public DateTime Date { get; set;} = DateTime.Now; //? Default value?

        [Field("CALORIES", OracleDbType.Int64)]
        public int Calories { get; set; } = 0;

        [Field("PROTEINS", OracleDbType.Int64)] //current NUMBER(6,2) in ERD
        public int Proteins { get; set; } = 0;

        [Field("FAT", OracleDbType.Int64)]
        public int Fat { get; set; } = 0;

        [Field("CARBONHYDRATES", OracleDbType.Int64)]
        public int Carbonhydrates { get; set; } = 0;

        public Track(DateTime date, int calories, int proteins, int fat, int carbonhydrates)
        {
            Date = date;
            Calories = calories;
            Proteins = proteins;
            Fat = fat;
            Carbonhydrates = carbonhydrates;
        }

        public override bool Equals(object? obj)
        {
            return obj is Track track &&
                   TrackID == track.TrackID &&
                   Date == track.Date &&
                   Calories == track.Calories &&
                   Proteins == track.Proteins &&
                   Fat == track.Fat &&
                   Carbonhydrates == track.Carbonhydrates;
        }
    }
}
