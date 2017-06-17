using CsvHelper.Configuration;
using PatientsImporter.Infrastructure.Dto;

namespace PatientsImporter.Infrastructure.CsvClassMap
{
  public class PatientCsv
  {
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Pesel { get; set; }
    public string Email { get; set; }
  }
  
  public sealed class PatientCsvClassMap : CsvClassMap<PatientCsv>
  {
    public PatientCsvClassMap()
    {
      Map(m => m.Name).Name("Imię");
      Map(m => m.Surname).Name("Nazwisko");
      Map(m => m.Pesel).Name("PESEL");
      Map(m => m.Email).Name("Email");
    }

    
  }
}