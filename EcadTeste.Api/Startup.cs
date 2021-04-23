using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using EcadTeste.Infra.Data.Context;
using EcadTeste.Infra.Data.Seeds;
using EcadTeste.Infra.IoC;
using Microsoft.OpenApi.Models;

namespace EcadTeste.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<EcadTesteContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("EcadTesteContext")));

            services.AddAutoMapper(typeof(Startup));

            DIContainer.RegisterDependencies(services);

            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy", builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API - Processo Seletivo Ecad",
                    Description = "API referente ao processo seletivo do Ecad",
                    Contact = new OpenApiContact
                    {
                        Name = "Flavio Rianelli",
                        Email = "frianelli.lopes@gmail.com"
                    },
                });
            });
            //services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API - Processo Seletivo Ecad");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("DefaultPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<EcadTesteContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetService<EcadTesteContext>().Seed();
            }
        }
    }
}
