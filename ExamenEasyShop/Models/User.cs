using System.ComponentModel.DataAnnotations;

namespace ExamenEasyShop.Models
{
    public class User
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }


        [StringLength(50)]
        public string? phone { get; set; }

        public Rol Rol { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
