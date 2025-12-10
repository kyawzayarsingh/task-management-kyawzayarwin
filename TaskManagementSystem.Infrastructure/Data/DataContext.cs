using Microsoft.EntityFrameworkCore;

namespace TaskManagementSystem.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public DbSet<Models.Task> Tasks { get; set; }
    }
}
