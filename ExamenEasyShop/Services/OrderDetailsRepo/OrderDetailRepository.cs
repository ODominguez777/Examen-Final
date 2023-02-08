using ExamenEasyShop.Data;
using ExamenEasyShop.Models;
using ExamenEasyShop.Services.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExamenEasyShop.Services.OrderDetailsRepo
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ExamenEasyShopContext context) : base(context)
        {

        }

        public async void DeleteByIds(string id)
        {
            string[] allId = id.Split("-");

            int orderId = Int32.Parse(allId[0]);
            int productId = Int32.Parse(allId[1]);
            var orderDetail = await _dbSet.FindAsync(orderId, productId);

            if (orderDetail ==  null)
            {
                throw new Exception("La entidad no existe");
            }

            _dbSet.Remove(orderDetail);
        }

        public async Task<OrderDetail> FindByIds(string id)
        {
            string[] allId = id.Split("-");

            int orderId = Int32.Parse(allId[0]);
            int productId = Int32.Parse(allId[1]);
            return await _dbSet.Include(o => o.Order).Include(o => o.Product).FirstOrDefaultAsync(m => m.OrderId == orderId && m.ProductId == productId);
        }

        public override async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            var orderDetail = _context.OrderDetail.Include(o => o.Order).Include(o => o.Product);
            return await orderDetail.ToListAsync();
        }
    
        

    }
}
