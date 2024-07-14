using BotGarden.Infrastructure.Contexts;
using BotGarden.Infrastructure.Data.Repositories;
using BotGardens.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BotGardens.Infrastructure.Repositories
{
    public class UsersRepository : GenericRepository<Users>
    {
        public UsersRepository(BotanicGardenContext context) : base(context) { }

        public async Task<Users> GetUserByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.userEmail == email);
        }
    }
}
