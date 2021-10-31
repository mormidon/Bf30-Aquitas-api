using Catalyte.Aquitas.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);

        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> CreateUserAsync(User user);
    }
}
