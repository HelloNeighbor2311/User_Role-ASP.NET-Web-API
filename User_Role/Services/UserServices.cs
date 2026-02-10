using User_Role.DTOs;
using User_Role.Models;
using User_Role.Respositories;

namespace User_Role.Services
{
    public class UserServices (IUserRepository repository): IUserServices
    {
        public async Task<UsersResponse> AddUserAsync(CreateUserRequest usersRequest)
        {
            var user = new Users
            {
                Username = usersRequest.Username,
                Password =  usersRequest.Password,
                Name = usersRequest.Name,
                CreatedDate = DateTime.UtcNow
            };
            var createdUserResponse = await repository.CreateUserAsync(user);
            return MapUserResponse(createdUserResponse);
        }

        public Task<bool> AssignRoleForUserAsync(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UsersResponse>> GetAllUsersAsync()
        {
            var users = await repository.GetAllUsersAsync();
            return users.Select(u => MapUserResponse(u)).ToList();
        }

        public async Task<UsersResponse?> GetUserByIdAsync(int id)
        {
            var user = await repository.GetUserByIdAsync(id);
            return (MapUserResponse(user));
        }

        public Task<bool> RemoveRoleForUserAsync(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserRequest users)
        {
            var existedUser = await repository.GetUserByIdAsync(id);
            if (existedUser is null) return false;
            existedUser.Name = users.Name;
            var updatedUser = await repository.UpdateUserAsync(existedUser);
            return true;
        }


        private UsersResponse MapUserResponse(Users user)
        {
            var userResponse = new UsersResponse
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                CreatedDate = user.CreatedDate,
                Roles = user.userRoles?.Select(s => s.role.RoleName).ToList() ?? new List<string?>()
            };
            return userResponse;

        }
    }
}
