using JobBoardApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace JobBoardApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<User> Users => Set<User>();
        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<JobApplication> Applications => Set<JobApplication>();
    }
}
