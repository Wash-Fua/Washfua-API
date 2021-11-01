using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WashFua.Dtos;
using WashFua.Entities;
using WashFua.Repositories;

namespace WashFua.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository repository;

        public UsersController(IUsersRepository repository)
        {
            this.repository = repository;
        }
        
        // GET /users
        [HttpGet]
        public IEnumerable<UserDto> GetUsers()
        {
            var users = repository.GetUsers().Select(user => user.AsDto());
            return users;
        }
        
        // GET /users/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(Guid id)
        {
            var user = repository.GetUser(id);

            if (user is null)
            {
                return NotFound();
            }
            return user.AsDto();
        }

        // POST /users
        [HttpPost]
        public ActionResult<UserDto> CreateUser(CreateUserDto userDto)
        {
            User user = new()
            {
                Id = Guid.NewGuid(),
                firstName = userDto.firstName,
                lastName = userDto.lastName,
                email = userDto.email,
                username = userDto.username,
                password = userDto.password,
                dateCreated = DateTime.UtcNow
            };
            
            repository.CreateUser(user);
            
            return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user.AsDto());
        }
        
        // PUT /users/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(Guid id, UpdateUserDto userDto)
        {
            var existingUser = repository.GetUser(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            User updatedUser = existingUser with
            {
                firstName = userDto.firstName,
                lastName = userDto.lastName,
                email = userDto.email,
                username = userDto.username,
                password = userDto.password
            };
            
            repository.UpdateUser(updatedUser);

            return NoContent();
        }
        
        // DELETE /users/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(Guid id)
        {
            var existingUser = repository.GetUser(id);

            if (existingUser is null)
            {
                return NotFound();
            }
            
            repository.DeleteUser(id);

            return NoContent();
        }
    }
}