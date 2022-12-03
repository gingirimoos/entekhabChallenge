using System;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Persistence.Repositories;
using Infrastructure.Persistence.Dapper;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Sql;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=EntekhabChallenge.db"));
 

            services.AddScoped<ISqlDbContext, ApplicationDbContext>();
            services.AddScoped<IDapperContext, DapperContext>(x=>new DapperContext("Data Source=EntekhabChallenge.db"));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IDatabaseInit, DatabaseInit>();
            return services;
        }

        public static void MigrateDatabase(this IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<IDatabaseInit>();
            }
        }
    }

    public interface IDatabaseInit  
    {
    }


    public class DatabaseInit : IDatabaseInit
    {
        private readonly ISqlDbContext _sqlDbContext;
        public DatabaseInit(ISqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
            try
            {
                _sqlDbContext.DbContext().Database.Migrate();
            }
            catch (Exception e)
            {
                throw;
            }

            _sqlDbContext.DbContext().Database.EnsureCreated();
        }
    }
}
