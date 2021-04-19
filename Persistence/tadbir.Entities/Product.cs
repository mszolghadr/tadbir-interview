namespace tadbir.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Stock { get; set; }
        public byte DiscountPercentage { get; set; }
        public long Price { get; set; }
    }
}
