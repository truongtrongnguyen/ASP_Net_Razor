using Microsoft.EntityFrameworkCore;
using razprweb.models;

namespace razorweb.models;

public class MyBlogContext : DbContext
{
    public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
    {

    }
    public DbSet<Article> articles {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
    {
        base.OnConfiguring(optionbuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        base.OnModelCreating(modelbuilder);
    }
}