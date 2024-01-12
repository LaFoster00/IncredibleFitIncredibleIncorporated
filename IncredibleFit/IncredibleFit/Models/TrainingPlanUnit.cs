using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.IncredibleFit.Models
{
    public class TrainingPlanUnit
    {
        public string weekday { get; set; }
        public TrainingUnit trainingUnit { get; set; }

        public int exerciseCount { get; set; }
        public bool visibility { get; set; } = true;

        public TrainingPlanUnit(string weekday, TrainingUnit trainingUnit)
        {
            this.weekday = weekday;
            this.trainingUnit = trainingUnit;
        }
    }
}
