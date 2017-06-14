using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using PatientsImporter.Infrastructure.Commands;
using PatientsImporter.Infrastructure.Commands.Patient;
using PatientsImporter.Infrastructure.Dto;

namespace PatientsImporter.Controllers
{
  public class PatientController : ControllerBase
  {
    public PatientController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
    {
    }

    [HttpGet]
    public async Task<ActionResult> CreatePatient(CreatePatients command)
    {
      await CommandDispatcher.DispatchAsync(command);

      return View();
    }
  }
}