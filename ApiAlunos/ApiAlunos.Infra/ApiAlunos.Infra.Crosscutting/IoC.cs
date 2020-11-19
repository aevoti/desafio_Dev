using ApiAlunos.Domain.Interfaces.Repository;
using ApiAlunos.Domain.Interfaces.Service;
using ApiAlunos.Infra.Data.Repository;
using ApiAlunos.Infra.Data.Context;
using ApiAlunos.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ApiAlunos.Infra.Crosscutting
{
    public static class IoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddDbContext<AppDbContext>();
        }
    }
}
