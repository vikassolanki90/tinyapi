var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogContext>(opt=>opt.UseInMemoryDatabase("blogdb"));
builder.Services.AddScoped<BlogService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", IEnumerable<Blog> (http) => { 
    var blogService = http.RequestServices.GetService<BlogService>();
    return blogService?.GetAll();
});
app.MapPost("/", async (http) => { 
    var blog = await http.Request.ReadFromJsonAsync<Blog>();
    var blogService = http.RequestServices.GetService<BlogService>();
    blogService?.Save(blog!);
});


app.Run();
