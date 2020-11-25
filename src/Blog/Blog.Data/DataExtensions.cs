using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Blog.Data.Repository.Interface;
using Blog.Data.Repository.Implementation;

namespace Blog.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbConnection(config);
            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();


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
