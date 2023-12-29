using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.Models
{
    public class Ingredient
    {
        private string name;
        private int foodcategory;
        private double energy;
        private double proteincontent;
        private double fatcontent;
        private double roughagecontent;
        private double watercontent;
        private Quantityprice quantityprice;

        public Ingredient(string name, int foodcategory, double energy, double proteincontent, double fatcontent, double roughagecontent, double watercontent, Quantityprice quantityprice)
        {
            this.name = name;
            this.foodcategory = foodcategory;
            this.energy = energy;
            this.proteincontent = proteincontent;
            this.fatcontent = fatcontent;
            this.roughagecontent = roughagecontent;
            this.watercontent = watercontent;
            this.quantityprice = quantityprice;
        }

        public string Name { get { return name; } set { name = value; } }
        public int Foodcategory { get {  return foodcategory; } set {  foodcategory = value; } }
        public double Energy { get { return energy; } set { energy = value; } }
        public double Proteincontent { get {  return proteincontent; } set {  proteincontent = value; } }
        public double Fatcontent { get { return fatcontent; } set { fatcontent = value; } }
        public double Roughagecontent { get { return roughagecontent; } set { roughagecontent = value; } }
        public double Watercontent { get { return watercontent; } set { watercontent = value; } }
        public Quantityprice Quantityprice { get {  return quantityprice; } set {  quantityprice = value; } }
    }
}
