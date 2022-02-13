using System;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.IoC.Modules
{
    public static class ApplicationModule
    {
        public static IServiceCollection Register(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
