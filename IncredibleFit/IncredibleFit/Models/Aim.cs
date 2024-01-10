namespace IncredibleFit.Models
{
    public class Aim
    {
        private String _targetDescription;
        private double _targetWeight;

        public Aim(string targetDescription, double targetWeight)
        {
            this._targetDescription = targetDescription;
            this._targetWeight = targetWeight;
        }

        public string TargetDescription { get { return _targetDescription; } set { _targetDescription = value; } }
        public double TargetWeight{ get { return _targetWeight; } set { _targetWeight = value; } }
    }
}
