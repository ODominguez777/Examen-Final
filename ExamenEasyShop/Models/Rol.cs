using System.ComponentModel.DataAnnotations;

namespace ExamenEasyShop.Models
{
    public class Rol
    {
        public int Id { get; set; }
        [Required]
        [StringLength (50)]
        public string RolName { get; set; }
        
        public IEnumerable<User> Users { get; set; }
    }
}
