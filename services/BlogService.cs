public class BlogService{
    private readonly BlogContext blogContext;
    public BlogService(BlogContext blogContext)
    {
        this.blogContext = blogContext;
    }

    public void Save(Blog blog)
    {
        blogContext.Blogs.Add(blog);
        blogContext.SaveChanges();
    }

    public IEnumerable<Blog> GetAll()
    {
        return blogContext.Blogs;
    }
}