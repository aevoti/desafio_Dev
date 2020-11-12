using ApiAlunos.Context;
using ApiAlunos.Extensions;
using ApiAlunos.Interfaces;
using ApiAlunos.Repositorio;
using ApiAlunos.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO.Compression;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ApiAlunos
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });

            if (_env.IsDevelopment())
            {
                services.AddDbContext<AlunoDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );
            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<AlunoDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AzureConnection"))
                );
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddMvc(option => option.EnableEndpointRouting = false);
          
            //DI Services and Repos
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoAppService, AlunoAppService>();

            //Adicionando Compressão de resposta
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });


            // Swagger settings
            services.AddApiDoc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCustomSerilogRequestLogging();
            app.UseCors("EnableCORS");
            app.UseApiDoc();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseResponseCompression();
        }
    }
}
