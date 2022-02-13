using System;
using CleanArch.Domain.Interfaces.Repositories;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.IoC.Modules
{
    public static class DataModule
    {
        public static IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));
                
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
