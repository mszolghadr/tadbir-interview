namespace tadbir.Service.DTOs.InvoiceDTOs
{
    public class InvoiceRowDto
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public int DiscountPercentage { get; set; }
    }
}