namespace tadbir.Service.DTOs.InvoiceDTOs
{
    public class DetailedInvoiceRowDto
    {
        public string ProductTitle { get; set; }
        public int Quantity { get; set; }
        public int DiscountPercentage { get; set; }
        public long ProductUnitPrice { get; set; }
        public long DiscountedUnitPrice { get; set; }
        public long UnitDiscountAmount { get; set; }
        public long TotalPrice { get { return ProductUnitPrice * Quantity; } }
        public long TotalDiscountedPrice { get { return Quantity * DiscountedUnitPrice; } }
        public long TotalDiscountAmount { get { return UnitDiscountAmount * Quantity; } }
    }
}