using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Persistence.Repositories;
using Infrastructure.Persistence.Dapper;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Sql;
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
            return services;
        }
    }
}
