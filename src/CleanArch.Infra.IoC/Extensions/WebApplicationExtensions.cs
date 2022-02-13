using System;
using CleanArch.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanArch.Infra.IoC.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void Migrate(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger>();
                logger.LogError(ex, "Ocorreu um erro ao aplicar Migrations banco de dados!");
            }
        }
    }
}
