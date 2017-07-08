using System;
using PatientsImporter.Infrastructure.Dto;
using PatientsImporter.Infrastructure.ExtensionMethods;
using PatientsImporter.Models.Patients;

namespace PatientsImporter.Conventers
{
  public class PatientDtoToViewModelConventer : IConventer<PatientDto, PatientViewModel>
  {
    public PatientViewModel Convert(PatientDto source)
    {
      var result = new PatientViewModel(source.Pesel)
      {
        Email = source.Email,
        Name = source.Name,
        Surname = source.Surname,
        Age = GetAge(source.Pesel),
        Gender = source.Pesel.GetGender()
      };

      return result;
    }


    private static int GetAge(string pesel)
    {
      var today = DateTime.Now;
      var birthdate = pesel.GetBirthday();
      var age = today.Year - birthdate.Year;

      if (birthdate > today.AddYears(-age)) age--;

      return age;
    }
  }
}