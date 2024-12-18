using BackendAPI.Data; 
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:5001") 
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5071); 
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowFrontend");

app.UseRouting();

app.MapControllers();

app.Run();
