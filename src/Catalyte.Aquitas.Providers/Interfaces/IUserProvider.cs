using Catalyte.Aquitas.Utilities;
using Catalyte.Aquitas.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Providers.Interfaces
{
    public interface IUserProvider
    {
        Task<ProviderResponse<List<UserDTO>>> GetUsersAsync();

        Task<ProviderResponse<UserDTO>>GetUserByIdAsync(int userId);

        Task<ProviderResponse<UserDTO>>CreateUserAsync(UserDTO userDTO);
    }
}
