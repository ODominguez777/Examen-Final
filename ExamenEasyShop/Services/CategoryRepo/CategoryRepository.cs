using ExamenEasyShop.Data;
using ExamenEasyShop.Models;

using ExamenEasyShop.Services.Generic;

namespace ExamenEasyShop.Services.CategoryRepo
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ExamenEasyShopContext context) : base(context)
        {
        }
    }
}
