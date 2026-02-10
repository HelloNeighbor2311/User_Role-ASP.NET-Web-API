namespace User_Role.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string? RoleName { get; set; }

        public string? Desrciption { get; set; }

        public ICollection<UsersRoles>? userRoles { get; set; }
    }
}
