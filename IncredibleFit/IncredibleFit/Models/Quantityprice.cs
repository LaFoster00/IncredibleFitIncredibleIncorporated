using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.Models
{
    public class Quantityprice
    {
        private int _quantityUnit;
        private int _quantity;
        private double _priceLower;
        private double _priceUpper;

        public Quantityprice(int quantityUnit, int quantity, double priceLower, double priceUpper)
        {
            this._quantityUnit = quantityUnit;
            this._quantity = quantity;
            this._priceLower = priceLower;
            this._priceUpper = priceUpper;
        }

        public int QuantityUnit { get { return _quantityUnit; } set { _quantityUnit = value; } }
        public int Quantity { get { return _quantity;} set { _quantity = value; } }
        public double PriceLower { get { return _priceLower; } set { _priceLower = value; } }
        public double PriceUpper { get {  return _priceUpper; } set { _priceUpper = value; } }
    }
}
