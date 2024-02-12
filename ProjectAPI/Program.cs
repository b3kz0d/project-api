using Microsoft.EntityFrameworkCore;
using ProjectAPI;
using ProjectAPI.Exceptions;
using ProjectAPI.Services;
using ProjectAPI.Services.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjectDbContext>(options => 
        options.UseNpgsql(builder.Configuration.GetConnectionString("ProjectDb"))
    );
builder.Services.AddAutoMapper(typeof(CustomAutoMapperProfile));
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var context = serviceProvider.GetRequiredService<ProjectDbContext>();
    await SeedData.Initialize(context);
}

app.UseAuthorization();
app.MapControllers();
app.Run();

