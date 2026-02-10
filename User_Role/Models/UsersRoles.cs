namespace User_Role.Models
{
    public class UsersRoles
    {
        public int UsersId { get; set; }
        public int RolesId { get; set; }

        public Users? user { get; set; }
        public Roles? role { get; set; }
    }
}
