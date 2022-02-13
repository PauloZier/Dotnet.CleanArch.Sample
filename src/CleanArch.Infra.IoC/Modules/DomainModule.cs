using System;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.IoC.Modules
{
    public static class DomainModule
    {
        public static IServiceCollection Register(IServiceCollection services)
        {
            services.AddSingleton<AbstractValidator<Product>, ProductValidator>();

            return services;
        }
    }
}
