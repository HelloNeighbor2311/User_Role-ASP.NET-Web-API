namespace User_Role.DTOs
{
    public class UpdateUserRequest
    {
        public string? Name { get; set; }

        public List<string>? Roles { get; set; }
    }
}
