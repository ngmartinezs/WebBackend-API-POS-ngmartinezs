using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBackendAPIPOSngmartinezs.Data;
using WebBackendAPIPOSngmartinezs.Service;
using WebBackendAPIPOSngmartinezs.Repository;
using Microsoft.OpenApi.Models;

namespace WebBackend_API_POS_ngmartinezs
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
            services.AddScoped<ProductoRepositoryInterface, ProductoRepository>();
            services.AddScoped<ClienteRepositoryInterface, ClienteRepository>();
            services.AddScoped<FacturaVentaRepositoryInterface, FacturaVentaRepository>();

            services.AddScoped<ProductoServiceInterface, ProductoService>();
            services.AddScoped<ClienteServiceInterface, ClienteService>();
            services.AddScoped<FacturaVentaServiceInterface, FacturaVentaService>();

            services.AddControllers();
            AddSwagger(services);

            services.AddDbContext<WebBackendAPIPOSngmartinezsContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WebBackendAPIPOSngmartinezsContext")));

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend API POS ngmartinezs");
            });
        }


        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Backend API POS ngmartinezs {groupName}",
                    Version = groupName,
                    Description = "API que provee servicios para gestionar un proceso de venta.",
                    Contact = new OpenApiContact
                    {
                        Name = "@ngmartinezs",
                        Email = "ngmartinezs@gamil.com",
                        Url = new Uri("https://github.com/ngmartinezs/WebBackend-API-POS-ngmartinezs"),
                    }
                });
            });
        }
    }
}
