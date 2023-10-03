using Jazani.Domain.Admins.Repositories;
using Jazani.Infastructure.Admins.Persistences;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jazani.Infastructure.Cores.Contexts
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            services.AddTransient<IStateattentionRepository, StateattentionRepository>();
            services.AddTransient<ITupaRepository, TupaRepository>();

            return services;
        }
    }
}
