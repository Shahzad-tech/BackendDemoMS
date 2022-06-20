using Domain.Data;
using Domain.Models.Student;
using Domain.Models.Program;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Persistance.context
{
    public class DataContext : IdentityDbContext<ApplicationUser>{

        public DataContext()
        {
        }
  
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Programs> Programs { get; set; }

    }

}