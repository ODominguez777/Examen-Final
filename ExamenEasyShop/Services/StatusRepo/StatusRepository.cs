using ExamenEasyShop.Data;
using ExamenEasyShop.Models;
using ExamenEasyShop.Services.Generic;

namespace ExamenEasyShop.Services.StatusRepo
{
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        public StatusRepository(ExamenEasyShopContext context) : base(context)
        {
        }
    }
}
