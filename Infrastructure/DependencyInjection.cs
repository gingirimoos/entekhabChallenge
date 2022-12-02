using Application.Common.Interfaces.Infrastructure;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<ISalaryCalculator, SalaryCalculator>();
            return services;
        }
    }
}
