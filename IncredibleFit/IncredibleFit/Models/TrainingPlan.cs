using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncredibleFit.SQL;

namespace IncredibleFit.Models
{
    [Entity("TRAINING PLAN")]
    public class TrainingPlan
    {
        [Field("id")]
        public int id { get; private set; }
        [Field("name")]
        public string name { get; set; }
        [Field("description")]
        public string description { get; set; }
        [Field("difficulty")]
        public string difficulty { get; set; }

        public TrainingPlanUnit[] trainingUnits { get; set; } = new TrainingPlanUnit[7];

        public TrainingPlan(string name, string description, string difficulty)
        {
            this.name = name;
            this.description = description;
            this.difficulty = difficulty;
        }
    }
}
