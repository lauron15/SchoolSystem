using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemSchool.Server.Models
{

    [Table("user")]
    public class Students
    {
        [Key]
        [Column("")]
        public int Id { get; set; }

    }
}
