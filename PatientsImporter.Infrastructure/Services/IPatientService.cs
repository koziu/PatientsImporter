using System.Collections.Generic;
using System.Threading.Tasks;
using PatientsImporter.Infrastructure.Dto;

namespace PatientsImporter.Infrastructure.Services
{
  public interface IPatientService
  {
    Task<IEnumerable<PatientDto>> GetAllAsync();
    Task<PatientDto> GetAsync(string taxId);
    Task SaveAsync(string name, string surname, string taxId, string email);
  }
}