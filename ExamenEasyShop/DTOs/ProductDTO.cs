namespace ExamenEasyShop.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }
        public int CountInStock { get; set; }
        public string ImageURL { get; set; }
        public int Rating { get; set; }
    }
}
