using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("QUANTITYPRICE")]
    public class Quantityprice
    {
        [ID, Field("QUANTITYPRICEID", OracleDbType.Int64)] //Correct data type for serial?
        public int QuantitypriceID { get; private set; } = 0;

        [Field("QUANTITYUNIT", OracleDbType.Varchar2)] //Domain in ERD
        public string Quantityunit { get; set; } = String.Empty;

        [Field("PRICELOWER", OracleDbType.Decimal)] //Number(4,2) in ERD
        public decimal PriceLower { get; set; } = 0;

        [Field("PRICEUPPER", OracleDbType.Decimal)] //Number(4,2) in ERD
        public decimal PriceUpper { get; set; } = 0;

        public Quantityprice(string quantityunit, decimal priceLower, decimal priceUpper)
        {
            Quantityunit = quantityunit;
            PriceLower = priceLower;
            PriceUpper = priceUpper;
        }
    }
}
