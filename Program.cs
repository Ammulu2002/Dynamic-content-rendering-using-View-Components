var builder = WebApplication.CreateBuilder(args);

// Enable CORS for frontend URL (localhost:3000 in this case)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // React frontend URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Enable CORS middleware
app.UseCors("AllowFrontend");

app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();

app.Run();
