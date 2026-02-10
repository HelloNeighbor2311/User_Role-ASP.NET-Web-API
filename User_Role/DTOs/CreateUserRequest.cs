using User_Role.Models;

namespace User_Role.DTOs
{
    public class CreateUserRequest
    {
        public int Id { get; set; }

        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
