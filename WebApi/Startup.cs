using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using Application;
using Infrastructure;
using Infrastructure.Persistence;
using Lib.Swagger;
using Microsoft.OpenApi.Models;
using WebApi.Middleware;
using WebApi.Utilities;

namespace WebApi
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

            services.AddApplication();
            services.AddInfrastructure();
            services.AddPersistence(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("EntekhabChallenge", new OpenApiInfo
                {
                    Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString(),
                    Title = "EntekhabChallenge",
                });

                c.SchemaFilter<SwaggerExcludeFilter>();

                var xmlFile = $"{Assembly.GetEntryAssembly()?.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddCors(o =>
            {
                o.AddPolicy("Default", policy => { policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
            });

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddMvc(o => o.InputFormatters.Insert(0, new RawRequestBodyFormatter()));
            services.AddStackPolicy(options =>
            {
                options.MaxConcurrentRequests = 1;
                options.RequestQueueLimit = 25;
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/EntekhabChallenge/swagger.json",
                    $"EntekhabChallenge {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}");
            });
            app.UseConcurrencyLimiter();

            app.UseRouting();
            app.UseCors("Default");
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}