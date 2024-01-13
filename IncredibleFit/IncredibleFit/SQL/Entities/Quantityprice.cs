using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("QUANTITYPRICE")]
    public class Quantityprice
    {
        [ID, Field("QUANTITYPRICEID", OracleDbType.Int32)]
        public int QuantitypriceID { get; private set; } = -1;

        [Field("QUANTITYUNIT", OracleDbType.Int16)] //Domain in ERD
        public QuantityUnit Quantityunit { get; set; } = QuantityUnit.Invalid;

        [Field("PRICELOWER", OracleDbType.Double)] 
        public double PriceLower { get; set; } = -1;

        [Field("PRICEUPPER", OracleDbType.Double)]
        public double PriceUpper { get; set; } = -1;

        private Quantityprice() { }

        public Quantityprice(short quantityunit, double priceLower, double priceUpper)
        {
            Quantityunit = quantityunit;
            PriceLower = priceLower;
            PriceUpper = priceUpper;
        }
    }
}
