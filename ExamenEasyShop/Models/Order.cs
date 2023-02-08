using System.ComponentModel.DataAnnotations;

namespace ExamenEasyShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string DateCreated { get; set; }

        [Required]
        [StringLength(50)]
        public string PostalCOde { get; set; }

        [Required]
        [StringLength(300)]
        public string Address { get; set; }


        public User User { get; set; }
        public Status Status { get; set; }
        public IEnumerable<OrderDetail> OrderSold { get; set; }

    }
}
