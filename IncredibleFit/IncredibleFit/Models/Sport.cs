using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncredibleFit.IncredibleFit.SQL;

namespace IncredibleFit.IncredibleFit.Models
{
    [Entity("SPORT")]
    internal class Sport
    {
        [Field("id")]
        public int id { get; private set; } 
        [Field("name")]
        public string name { get; set; }
        [Field("description")]
        public string description { get; set; }

        public Sport(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}
