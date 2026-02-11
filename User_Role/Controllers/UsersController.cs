using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using User_Role.DTOs;
using User_Role.Models;
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
            var user = await services.GetUserByIdAsync(id);
            if (user is null) return NotFound("The User with the given Id was not found");
            return Ok(user);
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
        [HttpDelete("{userId}/Roles/{roleId}")]
        public async Task<ActionResult> RemoveRoleForuser(int userId, int roleId)
        {
            var removed = await services.RemoveRoleForUserAsync(userId, roleId);
            return removed ? NoContent() : NotFound("The UserRole with the given userId and roleId was not found");
        }
        [HttpPut("{userId}/Roles/{roleId}")]
        public async Task<ActionResult> AssignRoleForuser(int userId, int roleId)
        {
            var assigned = await services.AssignRoleForUserAsync(userId, roleId);
            return assigned ? NoContent() : NotFound("The UserRole with the given userId and roleId was not found");
        }
        [HttpGet("paged")]
        public async Task<ActionResult<PageResult<UsersResponse>>> GetPagedUser([FromQuery]PaginationParam param)
        {
            return await services.PaginationForUserAsync(param);
        }
    }
}
