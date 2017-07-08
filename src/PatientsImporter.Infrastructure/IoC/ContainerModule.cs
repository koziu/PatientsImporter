using Autofac;
using AutoMapper;
using PatientsImporter.Infrastructure.IoC.Modules;
using PatientsImporter.Infrastructure.Mappers;

namespace PatientsImporter.Infrastructure.IoC
{
  public class ContainerModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
      builder.RegisterModule<RepositoryModule>();
      builder.RegisterModule<ValidationModule>();
      builder.RegisterModule<ServiceModule>();
      builder.RegisterModule<LoggingModule>();
    }
  }
}