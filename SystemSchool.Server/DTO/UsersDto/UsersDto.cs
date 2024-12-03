using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SystemSchool.Server.DTO.UsersDto
{
    public class UsersDto
    {
       
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

    }
}
