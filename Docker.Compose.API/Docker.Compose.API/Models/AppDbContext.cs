using Microsoft.EntityFrameworkCore;

namespace Docker.Compose.API.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}