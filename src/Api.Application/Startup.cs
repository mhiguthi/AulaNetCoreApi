using System;
using Api.Crosscutting.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
namespace Api.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);

            services.AddMvc();
            services.AddControllers();

            /*  services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Curso de API com AspNetCore 3.1 - Na Prática",
                    Description = "Arquitetura DDD",
                    TermsOfService = new Uri("http://www.google.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "MHF",
                        Email = "mhf@mail.com",
                        Url = new Uri("http://www.google.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de Licença de Uso",
                        Url = new Uri("http://www.google.com")
                    }
                });
            }); */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });

            /*  app.UseSwagger();
             app.UseSwaggerUI(c =>
             {
                 c.SwaggerEndpoint("/swagger/v1/swagger.json", "Curso de API com AspNetCore 3.1");
                 c.RoutePrefix = string.Empty;
             });

             app.UseRouting();

             app.UseAuthorization();

             app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllers();
             });*/
        }

    }
}
