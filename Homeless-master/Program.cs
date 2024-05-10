using Homeless.Authorization.Middlewares;
using Homeless.Authorization.Repositories;
using Homeless.Authorization.Services;
using Homeless.Database;
using Homeless.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HomelessDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IHomelessMessageRepository, HomelessMessageRepository>();
builder.Services.AddScoped<IHomelessRepository, HomelessRepository>();
builder.Services.AddScoped<IHelpPointRepository, HelpPointRepository>();
builder.Services.AddScoped<IInfoRepository, InfoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

// Добавление CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseMiddleware<JwtMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();