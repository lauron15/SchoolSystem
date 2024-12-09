using SystemSchool.Server.DTO.ClassesDto;
using SystemSchool.Server.Models;

namespace SystemSchool.Server.Interfaces
{
    public interface ICoursesRepository
    {
        Task<List<Courses>>GetAllAsync();

        Task<Courses?>GetByIdAsync(int id);

        Task<Courses>CreateAsync(Courses coursesModel);

        Task<Courses> UpdateAsync(int id, UpdateCoursesDto coursesDto);

        Task<Courses> DeleteAsync(int id);
    }
}
