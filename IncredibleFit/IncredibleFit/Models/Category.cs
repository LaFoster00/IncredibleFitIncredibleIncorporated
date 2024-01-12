using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncredibleFit.IncredibleFit.SQL;

namespace IncredibleFit.IncredibleFit.Models
{
    [Entity("CATEGORY")]
    internal class Category
    {
        [Field("id")]
        public int id { get; private set; }
        [Field("name")]
        public string name { get; set; }

        public Category(string name)
        {
            this.name = name;
        }
    }
}
