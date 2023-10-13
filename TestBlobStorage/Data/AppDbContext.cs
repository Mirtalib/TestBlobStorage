using Microsoft.EntityFrameworkCore;
using TestBlobStorage.Entitiy;

namespace TestBlobStorage.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            :base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
