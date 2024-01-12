using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncredibleFit.IncredibleFit.SQL;

namespace IncredibleFit.IncredibleFit.Models
{
    [Entity("EXERCISE")]
    public class Exercise
    {
        [Field("id")]
        public int id { get; private set; }
        [Field("name")]
        public string name { get; set; }
        [Field("description")]
        public string description { get; set; }
        [Field("duration")]
        public double duration { get; set; }

        public int[][] setsAndReps { get; set; }

        public Color strokeColor { get; set; } = Color.FromArgb("#00000000");
        public Color textColor { get; set; } = Color.FromArgb("#6E6E6E");

        public bool isFinished { get; set; } = false;

        public Exercise(string name, string description, double duration) 
        {
            this.name = name;
            this.description = description;
            this.duration = duration;
        }
    }
}
