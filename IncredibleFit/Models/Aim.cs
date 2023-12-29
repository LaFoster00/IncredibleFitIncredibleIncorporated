namespace IncredibleFit.Models
{
    public class Aim
    {
        private String targetDescription;
        private double targetWeight;

        public Aim(string targetDescription, double targetWeight)
        {
            TargetDescription = targetDescription;
            TargetWeight = targetWeight;
        }

        public string TargetDescription { get { return targetDescription; } set { targetDescription = value; } }
        public double TargetWeight{ get { return targetWeight; } set { targetWeight = value; } }
    }
}
