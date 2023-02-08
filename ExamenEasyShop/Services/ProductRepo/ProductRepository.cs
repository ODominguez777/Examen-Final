using ExamenEasyShop.Data;
using ExamenEasyShop.Models;
using ExamenEasyShop.Services.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExamenEasyShop.Services.ProductRepo
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ExamenEasyShopContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            var product = _context.Product.Include(p => p.Category);
            return await product.ToListAsync();
        }
        public override async Task<Product> GetByIdAsync(int id)
        {
            return await _dbSet.Include(p => p.Category).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
