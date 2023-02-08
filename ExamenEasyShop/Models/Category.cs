using System.ComponentModel.DataAnnotations;

namespace ExamenEasyShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string NameCategory { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
