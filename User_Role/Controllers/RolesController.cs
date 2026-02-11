using Microsoft.AspNetCore.Mvc;
using User_Role.DTOs;
using User_Role.Services;

namespace User_Role.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController(IRoleServices services): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<RolesResponse>>> GetAllRoles()
        {
            return await services.GetAllRolesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RolesResponse>> GetRoleById(int id)
        {
            
            var role =  await services.GetRoleByIdAsync(id);
            if (role is null) return NotFound("The Role with the given Id was not found");
            return Ok(role);
        }
        [HttpGet("Name{name}")]
        public async Task<ActionResult<RolesResponse>> GetRoleByName(string name)
        {

            var role = await services.GetRoleByNameAsync(name);
            if (role is null) return NotFound("The Role with the given name was not found");
            return Ok(role);
        }
        [HttpPost]
        public async Task<ActionResult<RolesResponse>> CreateRole(CreateRoleRequest request)
        {
            var role = await services.AddRoleAsync(request);
            return CreatedAtAction(nameof(GetRoleById), new { id = request.Id }, role);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRole(int id, UpdateRoleRequest request)
        {
            var updated = await services.UpdateRoleAsync(id, request);
            return updated ? NoContent() : NotFound("The Role with the given Id was not found");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await services.DeleteRoleAsync(id);
            return deleted ? NoContent() : NotFound("The Role with the given Id was not found");
        }
    }
}
