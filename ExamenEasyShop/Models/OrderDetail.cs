using System.ComponentModel.DataAnnotations;

namespace ExamenEasyShop.Models
{
    
    public class OrderDetail
    {

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]

        public int Quantity { get; set; }

        [Required]

        public decimal UnitPrice { get; set; }

        [Required]

        public decimal Subtotal { get; set; }





    }
}
