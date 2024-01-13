using Oracle.ManagedDataAccess.Client;

namespace IncredibleFit.SQL.Entities
{
    [Entity("QUANTITYPRICE")]
    public class Quantityprice : BindableObject
    {
        [ID, Field("QUANTITYPRICEID", OracleDbType.Int32), AutoIncrement]
        public int QuantitypriceID
        {
            get => (int)GetValue(QuantitypriceIDProperty);
            private set => SetValue(QuantitypriceIDProperty, value);
        }
        
        [Field("QUANTITYUNIT", OracleDbType.Int16)] //Domain in ERD
        public QuantityUnit Quantityunit
        {
            get => (QuantityUnit)GetValue(QuantityunitProperty);
            set => SetValue(QuantityunitProperty, value);
        }

        [Field("PRICELOWER", OracleDbType.Double)]
        public double PriceLower
        {
            get => (double)GetValue(PriceLowerProperty);
            set => SetValue(PriceLowerProperty, value);
        }

        [Field("PRICEUPPER", OracleDbType.Double)]
        public double PriceUpper
        {
            get => (double)GetValue(PriceUpperProperty);
            set => SetValue(PriceUpperProperty, value);
        }

        public static readonly BindableProperty QuantitypriceIDProperty =
            BindableProperty.Create(
                nameof(QuantitypriceID), 
                typeof(int), 
                typeof(Quantityprice), 
                -1);
        
        public static readonly BindableProperty QuantityunitProperty =
            BindableProperty.Create(
                nameof(Quantityunit), 
                typeof(QuantityUnit), 
                typeof(Quantityprice), 
                QuantityUnit.Invalid);

        public static readonly BindableProperty PriceLowerProperty =
            BindableProperty.Create(
                nameof(PriceLower), 
                typeof(double), 
                typeof(Quantityprice), 
                -1.0);

        public static readonly BindableProperty PriceUpperProperty =
            BindableProperty.Create(
                nameof(PriceUpper), 
                typeof(double), 
                typeof(Quantityprice), 
                -1.0);

        private Quantityprice() { }

        public Quantityprice(short quantityunit, double priceLower, double priceUpper)
        {
            Quantityunit = quantityunit;
            PriceLower = priceLower;
            PriceUpper = priceUpper;
        }
    }
}
