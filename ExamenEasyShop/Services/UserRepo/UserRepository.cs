using ExamenEasyShop.Data;
using ExamenEasyShop.Models;
using ExamenEasyShop.Services.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExamenEasyShop.Services.UserRepo
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(ExamenEasyShopContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            var user = _context.User.Include(u => u.Rol);
            return await user.ToListAsync();
        }

        public override async Task<User> GetByIdAsync(int id)
        {

            return await _dbSet.Include(u => u.Rol).FirstOrDefaultAsync(p => p.Id ==id);
        }

    }
}
