using SystemSchool.Server.DTO.UsersDto;
using SystemSchool.Server.Models;

namespace SystemSchool.Server.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<Users>> GetAllAsync();
        Task<Users?> GetByIdAsync(int id);

        Task<Users> CreateAsync(Users usersModel);

        Task<Users?> UpdateAsync(int id, UpdateUsersDto usersDto);

        Task<Users?> DeleteAsync(int id);

    }
}
