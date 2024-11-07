using CalcApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace CalcApp.Server.Commands
{
    public class CalcDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public DbSet<UserModel> Users { get; set; } = null!;
        public DbSet<OperationModel> Operations { get; set; } = null!;

        public CalcDbContext(DbContextOptions<CalcDbContext> calcOptions) : base(calcOptions)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection)"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
