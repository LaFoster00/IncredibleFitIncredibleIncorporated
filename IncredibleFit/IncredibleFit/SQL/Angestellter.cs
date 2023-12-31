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
        [Field("ID")]
        public int id { get; private set; }

        [Field("NAME")]
        public string name { get; set; }

        [Field("GEHALT")]
        public double gehalt { get; set; }

        [Field("KOMISSION")]
        public double komission { get; set; }

        [Field("CHEF")]
        public int chef {get; set; }
    }
}
