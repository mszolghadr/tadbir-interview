namespace tadbir.Entities
{
    public class InvoiceRow
    {
        public long InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public byte DiscountPercentage { get; set; }

        public long DiscountedUnitPrice { get { return Product != null ? Product.UnitPrice - (Product.UnitPrice * DiscountPercentage) / 100 : 0; } }
        public long UnitDiscountAmount { get { return Product != null ? (DiscountPercentage * Product.UnitPrice) / 100 : 0; } }
    }
}