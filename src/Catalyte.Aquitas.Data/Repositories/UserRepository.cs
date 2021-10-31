using Catalyte.Aquitas.Data.Context;
using Catalyte.Aquitas.Data.Interfaces;
using Catalyte.Aquitas.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApparelCtx _ctx;

        public UserRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _ctx.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _ctx.Users.FindAsync(userId);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();

            return user;
        }

    }
}
