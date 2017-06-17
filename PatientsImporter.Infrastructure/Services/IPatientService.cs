using System.Collections.Generic;
using System.Threading.Tasks;
using PatientsImporter.Infrastructure.Dto;

namespace PatientsImporter.Infrastructure.Services
{
  public interface IPatientService : IService
  {
    Task<IEnumerable<PatientDto>> GetAllAsync();
    Task<PatientDto> GetAsync(string pesel);
    Task SaveAsync(string name, string surname, string pesel, string email);
  }
}