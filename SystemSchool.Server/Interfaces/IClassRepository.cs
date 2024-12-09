using SystemSchool.Server.DTO.ClassesDto;
using SystemSchool.Server.Models;

namespace SystemSchool.Server.Interfaces
{
    public interface IClassRepository
    {
        Task<List<Classes>> GetAllAsync();

        Task<Classes?> GetByIdAsync(int id);

        Task<Classes> CreateAsync(Classes classesMoldel);

        Task<Classes?> UpdateAsync(int id, UpdateCoursesDto classesDto);

        Task<Classes?> DeleteAsync(int id);

    }
}
