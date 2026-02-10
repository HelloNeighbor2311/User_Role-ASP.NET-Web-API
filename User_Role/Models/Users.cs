namespace User_Role.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<UsersRoles>? userRoles { get; set; }


    }
}
