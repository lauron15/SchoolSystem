using System.Runtime.CompilerServices;
using SystemSchool.Server.DTO.UsersDto;
using SystemSchool.Server.Models;

namespace SystemSchool.Server.Mappers
{
    public static class UsersMappers
    {
        public static UsersDto ToUsersDto(this Users usersModel)
        {
            return new UsersDto
            {
                Id = usersModel.Id,
                Username = usersModel.Username,
               

            };
        }

        public static Users ToUsersFromCreateDTO(this CreateUsersRequestDto usersDto)
        {
            return new Users
            {
                Username = usersDto.Username,
                Password = usersDto.Password
            };
        }
    }
}

