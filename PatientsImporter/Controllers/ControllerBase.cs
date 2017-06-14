using System.Web.Mvc;
using PatientsImporter.Infrastructure.Commands;

namespace PatientsImporter.Controllers
{
  [Route("[controller]")]
  public abstract class ControllerBase : Controller
  {
    protected readonly ICommandDispatcher CommandDispatcher;

    protected ControllerBase(ICommandDispatcher command)
    {
      CommandDispatcher = command;
    }
  }
}