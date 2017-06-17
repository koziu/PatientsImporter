using System;
using System.Collections.Generic;
using PatientsImporter.Infrastructure.Dto;
using PatientsImporter.Models.Patients;

namespace PatientsImporter.Conventers
{
  public class PatientsDtoToViewModelsConventer : IConventer<IEnumerable<PatientDto>, IEnumerable<PatientViewModel>>
  {
    private readonly IConventer<PatientDto, PatientViewModel> _conventer;

    public PatientsDtoToViewModelsConventer(IConventer<PatientDto, PatientViewModel> conventer)
    {
      _conventer = conventer;
    }

    public IEnumerable<PatientViewModel> Convert(IEnumerable<PatientDto> source)
    {
      var result = new List<PatientViewModel>();
      foreach (var patientDto in source)
      {
        result.Add(_conventer.Convert(patientDto));
      }

      return result;
    }
  }
}