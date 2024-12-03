using SystemSchool.Server.DTO.StudentsDto;
using SystemSchool.Server.Models;

namespace SystemSchool.Server.Mappers
{
    public static class StudentsMappers
    {
        public static StudentsDto ToStudentsDto(this Students studentsModel)
        {
            return new StudentsDto
            {
                Id = studentsModel.Id,
                Name = studentsModel.Name,
                Age = studentsModel.Age,
                Email = studentsModel.Email
            };
        }

        public static Students ToStudentsFromCreateDTO(this CreateStudentsRequestDto studentsDto)
        {
            return new Students
            {
                Name = studentsDto.Name,
                Age = studentsDto.Age,
                Email = studentsDto.Email
            };
        }



    }
}
