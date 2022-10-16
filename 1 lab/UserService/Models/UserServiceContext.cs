using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Models
{
    public class UserServiceContext : DbContext
    {
        public UserServiceContext(DbContextOptions<UserServiceContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> User { get; set; }
    }
}
