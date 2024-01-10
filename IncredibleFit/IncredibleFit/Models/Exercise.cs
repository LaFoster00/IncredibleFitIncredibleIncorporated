using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.Models
{
    //[Entity("EXERCISE")]
    public class Exercise
    {
        //[Field("id")]
        public int id { get; private set; }
        //[Field("name")]
        public string name { get; set; }
        //[Field("description")]
        public string description { get; set; }
        //[Field("duration")]
        public double duration { get; set; }

        public Exercise(int id, string name, string description, double duration) 
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.duration = duration;
        }
    }
}
