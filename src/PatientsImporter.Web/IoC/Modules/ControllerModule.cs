using Autofac;
using Autofac.Integration.Mvc;
using PatientsImporter.Controllers;

namespace PatientsImporter.IoC.Modules
{
  public class ControllerModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterControllers(typeof(PatientController).Assembly);
    }
  }
}