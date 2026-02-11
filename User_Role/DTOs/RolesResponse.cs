using User_Role.Models;

namespace User_Role.DTOs
{
    public class RolesResponse
    {
        public int Id { get; set; }
        public string? RoleName { get; set; }

        public string? Desrciption { get; set; }
        public int UserCount { get; set; }
    }
}
