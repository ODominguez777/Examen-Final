using System.ComponentModel.DataAnnotations;

namespace ExamenEasyShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(300)]
        public string ProductDescription { get; set; }

        [Required]

        public double Price { get; set; }

        [Required]

        public int CountInStock { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]

        public int Rating { get; set;}

        public Category Category { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }

    }
}
