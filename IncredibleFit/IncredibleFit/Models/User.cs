namespace IncredibleFit.IncredibleFit.Models
{
    public class User
    {
        private String _name;
        private double _weight;
        private double _height;
        private double _bodyFatPercentage;
        private int _basalMetabolicRate;
        private Aim _aim;
        private String _fitnesslevel;

        public User(string name, double weight, double height, double bodyFatPercentage, int basalMetabolicRate, Aim aim, string fitnesslevel)
        {
            this._name = name;
            this._weight = weight;
            this._height = height;
            this._bodyFatPercentage = bodyFatPercentage;
            this._basalMetabolicRate = basalMetabolicRate;
            this._aim = aim;
            this._fitnesslevel = fitnesslevel;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public double Weight { get { return _weight;} set { _weight = value; } }
        public double Height { get { return _height;} set { _height = value; } }  
        public double BodyFatPercentage { get { return _bodyFatPercentage; } set { _bodyFatPercentage = value; } }
        public int BasalMetabolicRate { get {  return _basalMetabolicRate; } set { _basalMetabolicRate= value; } }
        public Aim Aim { get {  return _aim; } set {  _aim = value; } }
        public string Fitnesslevel { get {  return _fitnesslevel; } set {  _fitnesslevel = value; } }

    }
}
