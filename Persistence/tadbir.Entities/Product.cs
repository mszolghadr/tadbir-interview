namespace tadbir.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int Stock { get; set; }
        public byte DiscountPercentage { get; set; }
        public long UnitPrice { get; set; }

        public long DiscountedUnitPrice { get { return UnitPrice - (UnitPrice * DiscountPercentage) / 100; } }
        public long UnitDiscountAmount { get { return (DiscountPercentage * UnitPrice) / 100; } }
    }
}
