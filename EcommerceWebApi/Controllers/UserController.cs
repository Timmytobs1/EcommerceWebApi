using EcommerceWebApi.Dtos.User;
using EcommerceWebApi.Interface;
using EcommerceWebApi.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace EcommerceWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
    
        private readonly IUserRepository repo;

        public UserController( IUserRepository repository  )
        {
            repo = repository;
         
        }
        [HttpGet]
        [Route("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var user = await repo.GetAllUsers();
            return Ok(user);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserId([FromRoute] Guid id)
        {
            var user = await repo.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await repo.CreateUser(userDto);
                return CreatedAtAction(nameof(GetUserId), new { id = user.Id }, userDto);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is MySqlException e && (e.Number == 1062))
                {
                    if (e.Message.Contains("Email") && e.Message.Contains("Phone"))
                    {
                        return BadRequest("Email and Phone Number already exists");
                    }
                    else if (e.Message.Contains("Email"))
                    {
                        return BadRequest("Email already exists");
                    }
                    return BadRequest("Phone Number already exist");
                }
                return BadRequest(ex.Message);
            }


        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await repo.LoginUser(userDto);
            if (user == null)
            {
                return Unauthorized("Invalid Login Details");
            }
            return Ok(new {  User = user.UserToUserDto() });
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await repo.UpdateUser(id, userDto);
                return Ok(userDto);
            }

            catch (DbUpdateException ex)
            {
                if (ex.InnerException is MySqlException e && (e.Number == 1062))
                {
                    if (e.Message.Contains("Email"))
                    {
                        return BadRequest("Email already exists");
                    }
                    return BadRequest("Phone Number already exist");
                }
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await repo.DeleteUser(id);
            return Ok(user);
        }


    }
}
