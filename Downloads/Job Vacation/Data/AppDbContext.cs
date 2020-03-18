using Microsoft.EntityFrameworkCore;
using Job_Vacation.Models;

namespace Job_Vacation.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Seeker> seekers { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Job> jobs { get; set; }
        public DbSet<Administrator> administrators { get; set; }
        public DbSet<TakeJob> takejobs { get; set; }
        public AppDbContext(DbContextOptions options) : base (options) 
        {

        }
    }
}