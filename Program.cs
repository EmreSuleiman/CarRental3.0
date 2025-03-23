using CarRental3._0.Data;
using CarRental3._0.Interfaces;
using CarRental3._0.Models;
using CarRental3._0.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));


// Register the background service
builder.Services.AddHostedService<CarStatusBackgroundService>();

// Use AppUser as the Identity user
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();

var app = builder.Build();

// Seed data if enabled in configuration
var seedData = builder.Configuration.GetValue<bool>("SeedData");
if (seedData)
{
    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        try
        {
            await Seed.SeedDataAsync(serviceProvider);
            await Seed.SeedUsersAndRolesAsync(serviceProvider);
        }
        catch (Exception ex)
        {
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();