using ExamenEasyShop.Services.CategoryRepo;
using ExamenEasyShop.Services.OrderDetailsRepo;
using ExamenEasyShop.Services.OrderRepo;
using ExamenEasyShop.Services.ProductRepo;
using ExamenEasyShop.Services.RolRepo;
using ExamenEasyShop.Services.StatusRepo;
using ExamenEasyShop.Services.UserRepo;

namespace ExamenEasyShop.Configuration
{
    public interface IUnitOfWork
    {
        IRolRepository RolRepository { get; }
        IStatusRepository StatusRepository { get; }
        ICategoryRepository CategoryRepository { get; } 
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        void Commit();
        void Dispose();
    }
}
