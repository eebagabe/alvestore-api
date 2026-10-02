using Alvestore.Api.Data;
using Alvestore.Api.Interfaces;
using Alvestore.Api.Repositories;
using Alvestore.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Running alvestore api");

app.MapControllers();

app.Run();