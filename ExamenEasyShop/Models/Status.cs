using System.ComponentModel.DataAnnotations;

namespace ExamenEasyShop.Models
{
    public class Status
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusName { get; set; }

        public IEnumerable<Order> Orders { get; set; }

    }
}
