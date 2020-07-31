using Alunos.Application.Errors;
using Alunos.Application.UseCases;
using Alunos.Application.ViewModels;
using Alunos.Domain;
using Alunos.Infra.Data;
using Alunos.Infra.Data.Alunos;
using ApiAlunos;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Alunos.Infra.CrossCutting.IoC
{
    public static class NativeBootstrapperInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            // Application Use Cases
            services.AddScoped<IRequestHandler<RegisterAluno, bool>, RegisterAlunoHandler>();
            services.AddScoped<IRequestHandler<DeleteAluno, bool>, DeleteAlunoHandler>();
            services.AddScoped<IRequestHandler<UpdateAluno, bool>, UpdateAlunoHandler>();
            services.AddScoped<IRequestHandler<GetAlunos, PaginatedList<AlunoViewModel>>, GetAlunosHandler>();
            services.AddScoped<IRequestHandler<GetAlunoById, AlunoViewModel>, GetAlunoByIdHandler>();

            // Error handling
            services.AddScoped<INotificationHandler<Error>, ErrorHandler>();


            // Infra Data
            services.AddScoped<AppDbContext>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddTransient<AlunosSeedDataService>();


        }
    }
}
