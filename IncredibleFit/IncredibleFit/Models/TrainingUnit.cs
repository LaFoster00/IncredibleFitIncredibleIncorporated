using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncredibleFit.IncredibleFit.SQL;

namespace IncredibleFit.IncredibleFit.Models
{
    [Entity("TRAINING UNIT")]
    public class TrainingUnit
    {
        [Field("id")]
        public int id { get; private set; }
        [Field("name")]
        public string name { get; set; }
        [Field("description")]
        public string description { get; set; }
        [Field("difficulty")]
        public string difficulty { get; set; }

        public List<Exercise> exercises { get; set; } = new List<Exercise>();

        public TrainingUnit(string name, string description, string difficulty)
        {
            this.name = name;
            this.description = description;
            this.difficulty = difficulty;
        }
    }
}
