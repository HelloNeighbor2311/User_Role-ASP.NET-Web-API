using Microsoft.AspNetCore.Mvc.RazorPages;
using User_Role.DTOs;
using User_Role.Models;

namespace User_Role.Respositories
{
    public interface IUserRepository 
    {
        Task<List<Users>> GetAllUsersAsync();
        Task<Users> GetUserByIdAsync(int id);
        Task<Users> CreateUserAsync(Users obj);
        Task<Users> UpdateUserAsync(Users obj);
        Task DeleteUserAsync(Users user);
        Task<bool> AssignRoleForUser(int userId, int roleId);
        Task<bool> RemoveRoleForUser(int userId, int roleId);
        Task<IEnumerable<Users>> GetPageResultUsersAsync(int pageSize, int pageNum);

    }
}
