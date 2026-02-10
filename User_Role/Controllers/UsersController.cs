using Microsoft.AspNetCore.Mvc;
using User_Role.DTOs;
using User_Role.Services;

namespace User_Role.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(IUserServices services) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<UsersResponse>> CreateUsers(CreateUserRequest userRequest)
        {
            var createdUser = await services.AddUserAsync(userRequest);
            return CreatedAtAction(nameof(GetUserById), new { id = userRequest.Id }, createdUser);
        }
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

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UpdateUserRequest user)
        {
            var updated = await services.UpdateUserAsync(id, user);
            return updated ? NoContent() : NotFound("The User with the given Id was not found !");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var deleted = await services.DeleteUserAsync(id);
            return deleted ? NoContent() : NotFound("The User with the given Id was not found");
        }

    }
}
