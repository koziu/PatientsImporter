using System.Reflection;
using Autofac;
using PatientsImporter.Infrastructure.Services;
using Module = Autofac.Module;

namespace PatientsImporter.Infrastructure.IoC.Modules
{
  public class ServiceModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      var assembly = typeof(ServiceModule)
        .GetTypeInfo()
        .Assembly;

      builder.RegisterAssemblyTypes(assembly)
        .Where(x => x.IsAssignableTo<IService>())
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();
    }
  }
}