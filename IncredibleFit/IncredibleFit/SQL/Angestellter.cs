using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.IncredibleFit.SQL
{
    [Entity("ANGESTELLTER")]
    public class Angestellter
    {
        [Field("ID", OracleDbType.Int32), ServersideSetup] public int Id { get; private set; } = 25;

        [Field("NAME", OracleDbType.Varchar2)] public string Name { get; set; }

        [Field("VORNAME", OracleDbType.Varchar2)] public string? Vorname { get; set; }

        [Field("GEHALT", OracleDbType.Double)] public double? Gehalt { get; set; }

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
