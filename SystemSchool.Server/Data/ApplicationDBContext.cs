using Microsoft.EntityFrameworkCore;
using SystemSchool.Server.Models;


namespace SystemSchool.Server.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions dbContextOptions)
            : base (dbContextOptions)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Classes> Classes { get; set; }



        //Um exemplo de como deve ser: public DbSet<Repetir> Repetir { get; set;}
        // Aqui eu vou criar as diretivas para as minhas tabelas. 
        // é como se fosse o repository do java.

    }
}
