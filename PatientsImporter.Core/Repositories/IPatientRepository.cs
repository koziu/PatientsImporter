using System.Collections.Generic;
using System.Threading.Tasks;
using PatientsImporter.Core.Domain;

namespace PatientsImporter.Core.Repositories
{
  public interface IPatientRepository : IRepository
  {
    Task<IEnumerable<Patient>> GetAllAsync();
    Task<Patient> GetAsync(string pesel);
    Task AddAsync(Patient patient);
    Task UpdateAsync(Patient patient);
    Task RemoveAsync(string pesel);

  }
}