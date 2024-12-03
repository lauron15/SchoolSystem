using System.ComponentModel.DataAnnotations.Schema;

namespace SystemSchool.Server.DTO.CoursesDto
{
    public class CoursesDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? workload { get; set; }
    }
}
