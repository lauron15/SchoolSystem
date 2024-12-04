using SystemSchool.Server.DTO.CoursesDto;
using SystemSchool.Server.Models;

namespace SystemSchool.Server.Mappers
{
    public static class CoursesMappers
    {
        public static CoursesDto ToCoursesDto(this Courses coursesModel)
        {
            return new CoursesDto
            {
                Id = coursesModel.Id,
                Name = coursesModel.Name,
                workload = coursesModel.Workload
            };
        }

        public static Courses ToCoursesFromCreateDTO(this CreateCoursesRequestDto coursesDto)
        {
            return new Courses
            {
                Name = coursesDto.Name,
                Workload = coursesDto.workload
            };
        }
    }
}
