using System.ComponentModel;

namespace PatientsImporter.Models.Patients
{
  public class PatientViewModel
  {
    public PatientViewModel(string pesel)
    {
      Pesel = pesel;
    }

    [DisplayName("PESEL")]
    public string Pesel { get; set; }

    [DisplayName("Email")]
    public string Email { get; set; }

    [DisplayName("Imię")]
    public string Name { get; set; }

    [DisplayName("Nazwisko")]
    public string Surname { get; set; }

    [DisplayName("Wiek")]
    public int Age { get; set; }

    [DisplayName("Płeć")]
    public string Gender { get; set; }
  }
}