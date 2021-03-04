using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Identity.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Blog.Data.Repository.Interface;
using Blog.Data.Repository.Implementation;
using Blog.Data.Model;
using Microsoft.AspNetCore.Identity;

namespace Blog.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbConnection(config);
            services.AddRepositories();
            services.AddIdentityCore<User>().AddRoles<IdentityRole>();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IStoredFileRepository, StoredFileRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IDrawingRepository, DrawingRepository>();
            services.AddTransient<IUserProjectRepository, UserProjectRepository>();
            services.AddTransient<IUserTaskRepository, UserTaskRepository>();
            services.AddTransient<IUserPostRepository, UserPostRepository>();

            return services;
        }

        private static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(
                    config.GetConnectionString("BlogDbConnection"),
                    builder =>
                    {
                        builder.MigrationsAssembly("Blog.Data");
                    });
            });
            return services;
        }
    }
}
