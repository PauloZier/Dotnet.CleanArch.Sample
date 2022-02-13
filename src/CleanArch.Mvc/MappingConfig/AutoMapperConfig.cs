using System;
using CleanArch.Application.Mappings;

namespace CleanArch.Mvc.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(DomainToViewModelMappingProfile),
                typeof(ViewModelToDomainMappingProfile));
        }
    }
}
