using ExamenEasyShop.Data;
using ExamenEasyShop.Models;
using ExamenEasyShop.Services.Generic;

namespace ExamenEasyShop.Services.RolRepo
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        public RolRepository(ExamenEasyShopContext context) : base(context)
        {
        }
    }
}
