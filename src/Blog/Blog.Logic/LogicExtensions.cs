using Blog.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Blog.Logic.Profiles;
using Blog.Logic.Services.Interface;
using Blog.Logic.Services.Implementation;

namespace Blog.Logic
{
    public static class LogicExtensions
    {
        public static void AddLogicServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDataServices(config);

            services.AddServiceImplementations();
            services.AddMapper();
        }

        private static void AddMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfiles(MapperProfiles.SetProfiles());
            });
            services.AddSingleton(mappingConfig.CreateMapper());
        }

        private static void AddServiceImplementations(this IServiceCollection services)
        {
            services.AddTransient<IUserProjectService, UserProjectService>();
            services.AddTransient<IUserPostService, UserPostService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
