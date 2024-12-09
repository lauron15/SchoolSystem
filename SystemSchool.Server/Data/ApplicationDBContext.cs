using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SystemSchool.Server.Models;


namespace SystemSchool.Server.Data
{
    public class ApplicationDBContext : IdentityDbContext<Users>
    {

        public ApplicationDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Classes> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
Name = "admin",
NormalizedName = "ADMIN"
                },

                new IdentityRole
                {
Name = "User",
NormalizedName = "USER"
                },

            };

            builder.Entity<IdentityRole>().HasData(roles);

        }





        //Um exemplo de como deve ser: public DbSet<Repetir> Repetir { get; set;}
        // Aqui eu vou criar as diretivas para as minhas tabelas. 
        // é como se fosse o repository do java.

    }
}
