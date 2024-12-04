using SystemSchool.Server.Models;

namespace SystemSchool.Server.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<Users>> GetAllAsync();
    }
}
