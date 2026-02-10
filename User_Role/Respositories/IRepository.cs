using User_Role.Models;

namespace User_Role.Respositories
{
    public interface IUserRepository 
    {
        Task<List<Users>> GetAllUsersAsync();
        Task<Users> GetUserByIdAsync(int id);
        Task<Users> CreateUserAsync(Users obj);
        Task<bool> UpdateUserAsync(int id, Users obj);
        Task<bool> DeleteUserAsync();

    }
}
