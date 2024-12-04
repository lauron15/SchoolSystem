using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemSchool.Server.Models
{

    [Table("courses")]
    public class Courses
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("workload")]
        public string? Workload { get; set; }



    }
}
