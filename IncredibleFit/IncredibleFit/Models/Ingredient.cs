using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.Models
{
    public class Ingredient
    {
        private string _name;
        private int _foodcategory;
        private double _energy;
        private double _proteincontent;
        private double _fatcontent;
        private double _roughagecontent;
        private double _watercontent;
        private Quantityprice _quantityprice;

        public Ingredient(string name, int foodcategory, double energy, double proteincontent, double fatcontent, double roughagecontent, double watercontent, Quantityprice quantityprice)
        {
            this._name = name;
            this._foodcategory = foodcategory;
            this._energy = energy;
            this._proteincontent = proteincontent;
            this._fatcontent = fatcontent;
            this._roughagecontent = roughagecontent;
            this._watercontent = watercontent;
            this._quantityprice = quantityprice;
        }

        public string Name { get { return _name; } set { _name = value; } }
        public int Foodcategory { get {  return _foodcategory; } set {  _foodcategory = value; } }
        public double Energy { get { return _energy; } set { _energy = value; } }
        public double Proteincontent { get {  return _proteincontent; } set {  _proteincontent = value; } }
        public double Fatcontent { get { return _fatcontent; } set { _fatcontent = value; } }
        public double Roughagecontent { get { return _roughagecontent; } set { _roughagecontent = value; } }
        public double Watercontent { get { return _watercontent; } set { _watercontent = value; } }
        public Quantityprice Quantityprice { get {  return _quantityprice; } set {  _quantityprice = value; } }
    }
}
