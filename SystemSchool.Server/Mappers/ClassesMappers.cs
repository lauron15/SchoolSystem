using SystemSchool.Server.DTO.ClassesDto;
using SystemSchool.Server.Models;

namespace SystemSchool.Server.Mappers
{
    public static class ClassesMappers
    {

        public static ClassesDto ToClassesDto(this Classes classesModel)
        {
            return new ClassesDto
            {
                Id = classesModel.Id,
                Number = classesModel.Number,
                Capacity = classesModel.Capacity,
            };
        }

        public static Classes ToClassesFromCreateDTO(this CreateClassesRequestDto classesDto)
        {
            return new Classes
            {
                Number = classesDto.Number,
                Capacity = classesDto.Capacity, 
            };
        }

    }
}
