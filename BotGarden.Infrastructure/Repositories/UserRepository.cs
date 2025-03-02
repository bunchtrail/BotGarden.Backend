using BotGarden.Domain.Models;
using BotGarden.Infrastructure.Contexts;
using BotGarden.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BotGardens.Infrastructure.Repositories
{
    public class UsersRepository : GenericRepository<User>
    {
        public UsersRepository(BotanicGardenContext context) : base(context) { }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserEmail == email);
        }
    }
}
