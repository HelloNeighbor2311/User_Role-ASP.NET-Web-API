using Microsoft.AspNetCore.Mvc;
using User_Role.DTOs;

namespace User_Role.Controllers
{
    public class UsersController: ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers()
        {

        }
    }
}
