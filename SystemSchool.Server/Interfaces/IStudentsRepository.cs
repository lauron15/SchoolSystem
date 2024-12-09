using SystemSchool.Server.DTO.StudentsDto;
using SystemSchool.Server.Models;

namespace SystemSchool.Server.Interfaces
{
    public interface IStudentsRepository
    {
        Task<List<Students>>GetAllAsync();
        Task<Students> GetByIdAsync(int id);

        Task<Students>CreateAsync(Students studentModel);

        Task<Students> UpdateAsync(int id, UpdateStudentsDto studentsDto);

        Task<Students> DeleteAsync(int id);
    }
}
