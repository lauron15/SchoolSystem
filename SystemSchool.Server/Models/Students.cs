using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemSchool.Server.Models
{

    [Table("students")]
    public class Students
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("class")]
        public String? Name { get; set; }

        [Column("email")]
        public String? Email{ get; set; }

        [Column("age")]
        public String? Age { get; set; }
    }
}
