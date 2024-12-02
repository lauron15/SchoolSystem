using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemSchool.Server.Models
{
    [Table("classes")]
    public class Classes
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("number")]
        public String? Number { get; set; }

        [Column("capacity")]
        public int Capacity { get; set; }
    }
}

