using Job.Models;
using Microsoft.EntityFrameworkCore;

namespace Job.Context
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Staff> Staffs { get; set; } = null!;
        protected ApplicationDbContext()
        {
        }
    }
}
