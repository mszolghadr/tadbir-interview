namespace tadbir.Service.DTOs.ProductDTOs
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int Stock { get; set; }
        public byte DiscountPercentage { get; set; }
        public long UnitPrice { get; set; }
    }
}