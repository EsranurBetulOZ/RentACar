using System;
using System.Threading.Tasks;
using Arac_Kiralama.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Arac_Kiralama.Data
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            string[] roleNames = { "Admin", "User" };

            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                    logger.LogInformation($"{roleName} rolü oluşturuldu.");
                }
            }

            // Admin kullanıcısı oluşturma
            var adminEmail = "esra@arackiralama.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var admin = new User
                {
                    UserName = "admin",
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    Age = 30,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, "Admin123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                    logger.LogInformation("Admin kullanıcısı oluşturuldu ve Admin rolüne atandı.");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        logger.LogError(error.Description);
                    }
                }
            }
        }
    }
}