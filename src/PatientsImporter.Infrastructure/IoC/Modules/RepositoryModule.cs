using System.Reflection;
using Autofac;
using PatientsImporter.Core.Repositories;
using Module = Autofac.Module;

namespace PatientsImporter.Infrastructure.IoC.Modules
{
  public class RepositoryModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      var assembly = typeof(RepositoryModule)
        .GetTypeInfo()
        .Assembly;

      builder.RegisterAssemblyTypes(assembly)
        .Where(x => x.IsAssignableTo<IRepository>())
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();
    }
  }
}