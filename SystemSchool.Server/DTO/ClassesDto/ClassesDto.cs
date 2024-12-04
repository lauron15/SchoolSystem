using System.ComponentModel.DataAnnotations.Schema;

namespace SystemSchool.Server.DTO.ClassesDto
{
    public class ClassesDto
    {
        public int Id { get; set; }
        public String? Number { get; set; }
        public int Capacity { get; set; }
    }
}
