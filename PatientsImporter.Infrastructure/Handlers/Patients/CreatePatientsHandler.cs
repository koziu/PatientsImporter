using System.Threading.Tasks;
using PatientsImporter.Infrastructure.Commands;
using PatientsImporter.Infrastructure.Commands.Patient;
using PatientsImporter.Infrastructure.Services;

namespace PatientsImporter.Infrastructure.Handlers.Patients
{
  public class CreatePatientsHandler : ICommandHandler<CreatePatients>
  {
    private readonly IPatientService _parientService;

    public CreatePatientsHandler(IPatientService parientService)
    {
      _parientService = parientService;
    }
    public async Task HandleAsync(CreatePatients command)
    {
      foreach (var createPatient in command.Patients)
      {
        await _parientService.SaveAsync(createPatient.Name, createPatient.Surname, createPatient.TaxId,
          createPatient.Email);
      }
    }
  }
}