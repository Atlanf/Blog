using Blog.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data
{
    public static class DbInitializer
    {
        private static string[] _roles = { "admin", "visitor" };
        private static string[] _users = { "admin", "testUser", "anotherTest" };

        public static async Task Seed(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                
                await SeedRoles(roleManager);
                await SeedUsers(userManager);
            }
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> manager)
        {
            foreach (var role in _roles)
            {
                if (!(await manager.RoleExistsAsync(role)))
                {
                    await manager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        /*
            Passwords for users are the same as their names 
        */
        private static async Task SeedUsers(UserManager<User> manager)
        {
            var hasher = new PasswordHasher<User>();
            foreach (var user in _users)
            {
                if (await manager.FindByNameAsync(user) == null)
                {
                    var newUser = new User
                    {
                        UserName = user,
                        NormalizedUserName = user.ToUpper(),
                        PasswordHash = hasher.HashPassword(null, user),
                    };

                    var result = await manager.CreateAsync(newUser);

                    if (result == IdentityResult.Success)
                    {
                        string role = user == "admin" ? "admin" : "visitor";
                        await SeedUserRole(manager, newUser, role);
                    }
                }
            }
        }

        private static async Task SeedUserRole(UserManager<User> userManager, User user, string role)
        {
            await userManager.AddToRoleAsync(user, role);
        }
    }
}
