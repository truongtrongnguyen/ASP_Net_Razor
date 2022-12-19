using Microsoft.EntityFrameworkCore;

namespace razorweb.modles;

public class MyBlogContext : DbContext
{
    // DbContextOptions là những thiết lập cho MyBlogContext
    public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
    {
    }

    public DbSet<Article> articles {get; set;}

    public  void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }

    public  void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}