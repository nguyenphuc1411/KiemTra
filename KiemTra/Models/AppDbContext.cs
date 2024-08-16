using KiemTra.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KiemTra.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}
