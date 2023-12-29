using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.Models
{
    public class Quantityprice
    {
        private int quantityUnit;
        private int quantity;
        private double priceLower;
        private double priceUpper;

        public Quantityprice(int quantityUnit, int quantity, double priceLower, double priceUpper)
        {
            this.quantityUnit = quantityUnit;
            this.quantity = quantity;
            this.priceLower = priceLower;
            this.priceUpper = priceUpper;
        }

        public int QuantityUnit { get { return quantityUnit; } set { quantityUnit = value; } }
        public int Quantity { get { return quantity;} set { quantity = value; } }
        public double PriceLower { get { return priceLower; } set { priceLower = value; } }
        public double PriceUpper { get {  return priceUpper; } set { priceUpper = value; } }
    }
}
