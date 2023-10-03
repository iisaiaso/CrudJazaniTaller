using Jazani.Application.Admins.Services;
using Jazani.Application.Admins.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Jazani.Application.Cores.Contexts
{
    public static class AplicationServiceRegistration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

           services.AddTransient<IStateattentionService, StateattentionService>();
           services.AddTransient<ITupaService, TupaService>();

            return services;
        }
    }
}
