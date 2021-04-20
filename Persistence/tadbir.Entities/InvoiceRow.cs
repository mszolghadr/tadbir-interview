namespace tadbir.Entities
{
    public class InvoiceRow
    {
        public long InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}