using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using log4net.Config;
using PatientsImporter.Infrastructure.DBContext;
using PatientsImporter.Infrastructure.IoC;
using PatientsImporter.IoC.Modules;

namespace PatientsImporter
{
  public class MvcApplication : HttpApplication
  {
    protected void Application_Start()
    {
      XmlConfigurator.Configure();
      var builder = new ContainerBuilder();
      builder.RegisterModule(new ContainerModule());
      builder.RegisterModule(new ControllerModule());
      builder.RegisterModule(new ConventerModule());
      builder.RegisterType<PatientnsImporterContext>().InstancePerRequest();
      var container = builder.Build();
      DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
  }
}
