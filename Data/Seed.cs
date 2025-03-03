using CarRental3._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarRental3._0.Data
{
    public static class Seed
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
        }
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                if (context == null)
                {
                    throw new InvalidOperationException("ApplicationDbContext is not registered in the service provider.");
                }

                await context.Database.MigrateAsync();

                if (!context.Cars.Any())
                {
                    context.Cars.AddRange(new List<Car>()
                {
                    new Car()
                    {
                            Brand = "Toyota",
                            Model = "Corolla",
                            Year = 2020,
                            DailyRate = 40,
                            Status = "В наличност",
                            Image = "https://www.cstatic-images.com/car-pictures/xl/USC90TOC021A021001.png"
                         },
                        new Car()
                        {
                            Brand = "Toyota",
                            Model = "Camry",
                            Year = 2020,
                            DailyRate = 50,
                            Status = "В наличност",
                            Image = "https://www.cstatic-images.com/car-pictures/xl/USC90TOC021A021001.png"
                        },
                        new Car()
                        {
                            Brand = "Toyota",
                            Model = "RAV4",
                            Year = 2020,
                            DailyRate = 60,
                            Status = "В наличност",
                            Image = "https://www.cstatic-images.com/car-pictures/xl/USC90TOS111A021001.png"
                        },
                        new Car()
                        {
                            Brand = "Toyota",
                            Model = "Highlander",
                            Year = 2020,
                            DailyRate = 70,
                            Status = "В наличност",
                            Image = "https://www.cstatic-images.com/car-pictures/xl/USC90TOS111A021001.png"
                        }
                    });
                    context.SaveChangesAsync();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                // Roles
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                // Users
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "admin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        FullName = "Admin",
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        FullName = "App User"
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}