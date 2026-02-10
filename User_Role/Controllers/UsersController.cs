using Microsoft.AspNetCore.Mvc;
using User_Role.DTOs;
using User_Role.Services;

namespace User_Role.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(IUserServices services): ControllerBase
    {
        //[HttpPost]
        //public async Task<ActionResult<UsersResponse>> CreateUsers(CreateUserRequest userRequest)
        //{
        //    var createdUser = await services.AddUserAsync(userRequest);
        //    return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        //}
        [HttpGet]
        public async Task<ActionResult<List<UsersResponse>>> GetAllUsers()
        {
            return await services.GetAllUsersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsersResponse>> GetUserById(int id)
        {
            return await services.GetUserByIdAsync(id);
        }

    }
}
