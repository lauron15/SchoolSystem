using System.ComponentModel.DataAnnotations.Schema;

namespace SystemSchool.Server.DTO.StudentsDto
{
    public class StudentsDto
    {

        public int Id { get; set; }
        public String? Name { get; set; }
        public String? Email { get; set; }
        public String? Age { get; set; }
    }
}
