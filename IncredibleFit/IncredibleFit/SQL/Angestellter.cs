using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.IncredibleFit.SQL
{
    [Entity("ANGESTELLTER")]
    public class Angestellter
    {
        [Field("ID")] public int Id { get; private set; } = -1;

        [Field("NAME")] public string Name { get; set; } = String.Empty;

        [Field("VORNAME")] public string? Vorname { get; set; } = null;

        [Field("GEHALT")] public double? Gehalt { get; set; } = null;

        [Field("KOMISSION")] public double? Komission { get; set; } = null;

        [Field("CHEF")] public int? Chef { get; set; } = null;
    }
}
