using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.IncredibleFit.Models
{
    public class CalorieTrack
    {
        private DateTime _date;
        private string _weekday;
        private double _kcal;
        private double _kh;
        private double _p;
        private double _f;

        public CalorieTrack(DateTime date, string weekday, double kcal, double kh, double p, double f)
        {
            this._date = date;
            this._weekday = weekday;
            this._kcal = kcal;
            this._kh = kh;
            this._p = p;
            this._f = f;
        }

        public DateTime DateTime { get { return this._date; } set { _date = value; } }
        public string Weekday { get { return this._weekday; } set { _weekday = value; } }
        public double Kcal { get { return this._kcal; } set { _kcal = value; } }
        public double Kh { get { return this._kh; } set { _kh = value; } }
        public double P { get { return this._p; } set { _p = value; } }
        public double F { get { return this._f; } set { _f = value; } }

        public override bool Equals(object obj)
        {
            return obj is CalorieTrack track &&
                   _date == track._date &&
                   _weekday == track._weekday &&
                   _kcal == track._kcal &&
                   _kh == track._kh &&
                   _p == track._p &&
                   _f == track._f &&
                   DateTime == track.DateTime &&
                   Weekday == track.Weekday &&
                   Kcal == track.Kcal &&
                   Kh == track.Kh &&
                   P == track.P &&
                   F == track.F;
        }
    }
}
