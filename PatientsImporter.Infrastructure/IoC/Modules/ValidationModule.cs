using System.Reflection;
using Autofac;
using FluentValidation;
using PatientsImporter.Infrastructure.Validators;
using IValidator = FluentValidation.IValidator;
using Module = Autofac.Module;


namespace PatientsImporter.Infrastructure.IoC.Modules
{
  public class ValidationModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      var assembly = typeof(ValidationModule).GetTypeInfo().Assembly;

      builder.RegisterAssemblyTypes(assembly).
        Where(x => x.IsAssignableTo<IValidator>()).
        AsImplementedInterfaces().InstancePerLifetimeScope();

      builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>().SingleInstance();
    }
  }
}