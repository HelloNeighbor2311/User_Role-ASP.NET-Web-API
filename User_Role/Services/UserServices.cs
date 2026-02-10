using User_Role.DTOs;
using User_Role.Models;

namespace User_Role.Services
{
    public class UserServices : IUserServices
    {
        public Task<UsersResponse> AddUserAsync(UsersResponse users)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AssignRoleForUserAsync(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UsersResponse>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsersResponse?> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveRoleForUserAsync(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(int id, Users users)
        {
            throw new NotImplementedException();
        }
    }
}
