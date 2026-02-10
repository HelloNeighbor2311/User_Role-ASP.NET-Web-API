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
            return await services.GetRoleByIdAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult<RolesResponse>> CreateRole(CreateRoleRequest request)
        {
            var role = await services.AddRoleAsync(request);
            return CreatedAtAction(nameof(GetRoleById), new { id = request.Id }, role);
        }
    }
}
