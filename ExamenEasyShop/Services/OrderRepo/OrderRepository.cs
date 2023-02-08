using ExamenEasyShop.Data;
using ExamenEasyShop.Models;
using ExamenEasyShop.Services.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExamenEasyShop.Services.OrderRepo
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ExamenEasyShopContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            var order = _context.Order.Include(o => o.Status).Include(o => o.User);
            return await order.ToListAsync();
        }
        public override async Task<Order> GetByIdAsync(int id)
        {
            return await _dbSet.Include(o => o.Status).Include(o => o.User).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
