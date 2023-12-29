namespace IncredibleFit.Models
{
    public class User
    {
        private String name;
        private double weight;
        private double height;
        private double bodyFatPercentage;
        private int basalMetabolicRate;
        private Aim aim;
        private String fitnesslevel;

        public User(string name, double weight, double height, double bodyFatPercentage, int basalMetabolicRate, Aim aim, string fitnesslevel)
        {
            this.name = name;
            this.weight = weight;
            this.height = height;
            this.bodyFatPercentage = bodyFatPercentage;
            this.basalMetabolicRate = basalMetabolicRate;
            this.aim = aim;
            this.fitnesslevel = fitnesslevel;
        }

        public string Name { get { return name; } set { name = value; } }
        public double Weight { get { return weight;} set { weight = value; } }
        public double Height { get { return height;} set { height = value; } }  
        public double BodyFatPercentage { get { return bodyFatPercentage; } set { bodyFatPercentage = value; } }
        public int BasalMetabolicRate { get {  return basalMetabolicRate; } set { basalMetabolicRate= value; } }
        public Aim Aim { get {  return aim; } set {  aim = value; } }
        public string Fitnesslevel { get {  return fitnesslevel; } set {  fitnesslevel = value; } }

    }
}
