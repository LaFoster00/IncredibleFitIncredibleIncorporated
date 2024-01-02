using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.IncredibleFit.SQL
{
    [Entity("ANGESTELLTER")]
    public class Angestellter
    {
        [ID, Field("ID", OracleDbType.Decimal), AutoIncrement] public decimal Id { get; private set; } = -1;

        [Field("NAME")] public string Name { get; set; }

        [Field("VORNAME")] public string? Vorname { get; set; }

        [Field("GEHALT")] public double? Gehalt { get; set; }

        [Field("KOMMISSION")] public double? Kommission { get; set; }

        [Field("CHEF")] public int? Chef { get; set; }

        private Angestellter() : this(String.Empty) { }

        public Angestellter(string name, string? vorname = null, double? gehalt = null, double? kommission = null,
            int? chef = null)
        {
            Name = name;
            Vorname = vorname;
            Gehalt = gehalt;
            Kommission = kommission;
            Chef = chef;
        }
    }
}
