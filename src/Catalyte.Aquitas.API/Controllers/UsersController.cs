using Catalyte.Aquitas.DTOs.User;
using Catalyte.Aquitas.Providers.Interfaces;
using Catalyte.Aquitas.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Microsoft.Extensions.Logging.ILogger<UsersController> _logger;
        private readonly IUserProvider _userProvider;

        public UsersController(ILogger<UsersController> logger, IUserProvider userProvider)
        {
            _logger = logger;
            _userProvider = userProvider;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserByIdAsync(int id)
        {
            var response = await _userProvider.GetUserByIdAsync(id);
            return response.ToActionResult();
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetCompaniesAsync()
        {
            var response = await _userProvider.GetUsersAsync();
            return response.ToActionResult();
        }

        [HttpPost]
        public async Task<ActionResult<List<UserDTO>>> CreateCompany([FromBody] UserDTO userDTO)
        {
            var result = await _userProvider.CreateUserAsync(userDTO);

            if (result.ResponseType == ResponseTypes.Created)
            {
                return new CreatedResult($"/purchases/{result.ResponseObject.LinkedInUsername}", result.ResponseObject);
            }

            return result.ToActionResult();
        }
    }
}
