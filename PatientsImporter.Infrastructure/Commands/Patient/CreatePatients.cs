using System.Collections.Generic;

namespace PatientsImporter.Infrastructure.Commands.Patient
{
  public class CreatePatients : ICommand
  {
    public IEnumerable<Patient> Patients { get; set; }
    
    public class Patient
    {
      public string Name { get; set; }
      public string Surname { get; set; }
      public string TaxId { get; set; }
      public string Email { get; set; }

    }
  }
}