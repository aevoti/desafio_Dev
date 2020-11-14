using System;
using ApiAlunos.Application.MappingProfiles;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ApiAlunos.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}