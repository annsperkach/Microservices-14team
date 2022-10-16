using Microsoft.EntityFrameworkCore;


namespace PostService.Models
{
    public class PostServiceContext : DbContext
    {
        public PostServiceContext(DbContextOptions<PostServiceContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Post> Post { get; set; }
        public DbSet<User> User { get; set; }
    }
}
