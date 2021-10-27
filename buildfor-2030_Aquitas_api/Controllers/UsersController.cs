﻿using buildfor_2030_Aquitas_api.Data;
using buildfor_2030_Aquitas_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace buildfor_2030_Aquitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ApiDbContext _dbContext;
    
        public UsersController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Users.ToListAsync());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("No user found with this id");
            }
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
           await _dbContext.Users.AddAsync(user);
           await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User userObj)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("No user found with this id");
            }
            else
            {
                user.FirstName = userObj.FirstName;
                user.LastName = userObj.LastName;
                user.ScreenName = userObj.ScreenName;
                user.Email = userObj.Email;
                user.PhoneNumber = userObj.PhoneNumber;
                user.Password = userObj.Password;
                user.LinkedInUsername = userObj.LinkedInUsername;
                user.Street = userObj.Street;
                user.City = userObj.City;
                user.Zip = userObj.Zip;
                user.Country = userObj.Country;
                await _dbContext.SaveChangesAsync();
                return Ok("User updated successfully");
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("No user found with this id");
            }
            else
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return Ok("User deleted");
            }
        }
    }
}