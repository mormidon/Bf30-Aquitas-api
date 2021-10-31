using AutoMapper;
using Catalyte.Aquitas.Data.Interfaces;
using Catalyte.Aquitas.Data.Model;
using Catalyte.Aquitas.DTOs.User;
using Catalyte.Aquitas.Providers.Interfaces;
using Catalyte.Aquitas.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Providers.Providers
{
    class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userRepository;
        private readonly Mapper _mapper;

        public UserProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = InitializeMapper();
        }

        public async Task<ProviderResponse<List<UserDTO>>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();

            return new ProviderResponse<List<UserDTO>>(
                _mapper.Map<List<UserDTO>>(users.ToList()),
                ResponseTypes.Success,
                Constants.Success);
        }

        public async Task<ProviderResponse<UserDTO>> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            return user == default
                ? new ProviderResponse<UserDTO>(
                    null,
                    ResponseTypes.NotFound,
                    $"User with Id:{userId} not found")
                : new ProviderResponse<UserDTO>(
                    _mapper.Map<UserDTO>(user),
                    ResponseTypes.Success,
                    Constants.Success);
        }

        public async Task<ProviderResponse<UserDTO>> CreateUserAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var savedUser = await _userRepository.CreateUserAsync(user);

            return new ProviderResponse<UserDTO>(
                _mapper.Map<UserDTO>(savedUser),
                ResponseTypes.Created,
                Constants.Success);
        }

        private Mapper InitializeMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
            }));
        }
    }
}
