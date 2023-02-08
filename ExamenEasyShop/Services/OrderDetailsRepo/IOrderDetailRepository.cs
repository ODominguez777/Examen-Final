using ExamenEasyShop.Models;
using ExamenEasyShop.Services.Generic;

namespace ExamenEasyShop.Services.OrderDetailsRepo
{
    public interface IOrderDetailRepository: IGenericRepository<OrderDetail>
    {
        Task<OrderDetail> FindByIds(string id);
        public void DeleteByIds(string id);
    }
}
