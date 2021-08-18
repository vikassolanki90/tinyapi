public class BlogContext : DbContext
{
   public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }
    public DbSet<Blog> Blogs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().Property(t => t.Id).ValueGeneratedOnAdd();
    }
}