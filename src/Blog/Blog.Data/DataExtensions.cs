using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

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
