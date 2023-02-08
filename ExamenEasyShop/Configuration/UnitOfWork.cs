
using ExamenEasyShop.Data;
using ExamenEasyShop.Services;
using ExamenEasyShop.Services.CategoryRepo;
using ExamenEasyShop.Services.OrderDetailsRepo;
using ExamenEasyShop.Services.OrderRepo;
using ExamenEasyShop.Services.ProductRepo;
using ExamenEasyShop.Services.RolRepo;
using ExamenEasyShop.Services.StatusRepo;
using ExamenEasyShop.Services.UserRepo;

namespace ExamenEasyShop.Configuration
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly ExamenEasyShopContext _context;
        public IRolRepository RolRepository { get; private set; }
        public IStatusRepository StatusRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public IOrderRepository OrderRepository { get; private set; }

        public IOrderDetailRepository OrderDetailRepository { get; private set; }

        public UnitOfWork(ExamenEasyShopContext context)
        {
            _context = context;
            RolRepository = new RolRepository(context);
            StatusRepository = new StatusRepository(context);
            CategoryRepository = new CategoryRepository(context);
            UserRepository = new UserRepository(context);
            ProductRepository = new ProductRepository(context); 
            OrderRepository= new OrderRepository(context);
            OrderDetailRepository= new OrderDetailRepository(context);
            
        }

        public  void Commit()
        {
             _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
