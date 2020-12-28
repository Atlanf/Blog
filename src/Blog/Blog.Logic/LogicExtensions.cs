using Blog.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Logic
{
    public static class LogicExtensions
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDataServices(config);

            return services;
        }
    }
}
