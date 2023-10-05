using Autofac;
using System.Reflection;

namespace Jazani.Infastructure.Cores.Contexts
{
    public class InfrastructureAutofacModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
