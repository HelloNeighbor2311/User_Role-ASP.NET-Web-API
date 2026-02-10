using User_Role.Models;

namespace User_Role.DTOs
{
    public class RolesResponse
    {
        public string? RoleName { get; set; }

        public string? Desrciption { get; set; }
        public List<string>? Users { get; set; }
    }
}
