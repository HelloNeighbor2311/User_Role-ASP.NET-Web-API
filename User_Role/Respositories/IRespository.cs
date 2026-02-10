using User_Role.Models;

namespace User_Role.Respositories
{
    public interface IUserRespository 
    {
        Task<List<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(int id);
        Task<Users> CreateAsync(Users obj);
        Task<bool> UpdateAsync(int id, Users obj);
        Task<bool> DeleteAsync();

    }
}
