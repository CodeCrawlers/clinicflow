using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ClinicFlow.Application.Common.Interfaces;

namespace ClinicFlow.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<Persistence.AppDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ClinicFlow.Infrastructure")));

            services.AddScoped<IAppDbContext, Persistence.AppDbContext>();

            return services;
        }
    }
}
