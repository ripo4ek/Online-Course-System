using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnlineCourseSystem.Areas.User.Data;
using OnlineCourseSystem.DAL.Context;
using System;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services
                                    .GetRequiredService<OnlineCourseSystemContext>();
                    DbInitializer.Initialize(context);

                    var roleStore = new RoleStore<Role>(context);
                    var roleManager = new RoleManager<Role>(roleStore,
                        new IRoleValidator<Role>[] { },
                        new UpperInvariantLookupNormalizer(),
                        new IdentityErrorDescriber(), null);

                    if (!roleManager.RoleExistsAsync(Roles.Administrator).Result)
                    {
                        //var role = new IdentityRole(Roles.Administrator);
                        var role = new Role(Roles.Administrator);
                        var result = roleManager.CreateAsync(role).Result;
                    }
                    if (!roleManager.RoleExistsAsync(Roles.Student).Result)
                    {
                        var role = new Role(Roles.Student);
                        var result = roleManager.CreateAsync(role).Result;
                    }
                    if (!roleManager.RoleExistsAsync(Roles.CourseCreator).Result)
                    {
                        var role = new Role(Roles.CourseCreator);
                        var result = roleManager.CreateAsync(role).Result;
                    }


                    var userStore = new UserStore<ApplicationUser>(context);
                    var userManager = new UserManager<ApplicationUser>(userStore, new OptionsManager<IdentityOptions>(new OptionsFactory<IdentityOptions>(new IConfigureOptions<IdentityOptions>[] { },
                            new IPostConfigureOptions<IdentityOptions>[] { })),
                        new PasswordHasher<ApplicationUser>(), new IUserValidator<ApplicationUser>[] { }, new IPasswordValidator<ApplicationUser>[] { },
                        new UpperInvariantLookupNormalizer(), new IdentityErrorDescriber(), null, null);
                    if (userStore.FindByEmailAsync("admin@mail.com", CancellationToken.None).Result == null)
                    {
                        var user = new ApplicationUser() { UserName = "Admin", Email = "admin@mail.com" };
                        var result = userManager.CreateAsync(user, "admin").Result;
                        if (result == IdentityResult.Success)
                        {
                            var roleResult = userManager.AddToRoleAsync(user, Roles.Administrator).Result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }

}
