using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using log4net;
using PatientsImporter.Core.Domain;
using PatientsImporter.Infrastructure.Dto;

namespace PatientsImporter.Infrastructure.Services
{
  public class UploadService : IUploadService
  {
    private readonly ICsvFileService _csvFileService;
    private readonly IPatientService _patientService;
    private readonly IValidator<Patient> _patientValidator;
    private readonly IMapper _mapper;
    private readonly ILog _log;

    public UploadService(ICsvFileService csvFileService, IPatientService patientService,
      IValidator<Patient> patientValidator, IMapper mapper, ILog log)
    {
      _csvFileService = csvFileService;
      _patientService = patientService;
      _patientValidator = patientValidator;
      _mapper = mapper;
      _log = log;
    }

    public async Task<IDictionary<PatientDto, ValidationResult>> UploadPatientsAsync(HttpPostedFileBase file)
    {
      _log.Info("Rozpoczęto wczytywanie pliku CSV.");
      if (file == null || file.ContentLength < 1)
        return null;

      var result = new Dictionary<PatientDto, ValidationResult>();
      var textReader = new StreamReader(file.InputStream);
      var patientsResult = _csvFileService.LoadPatients(textReader);

      foreach (var patient in patientsResult)
      {
        var validationResult = await _patientValidator.ValidateAsync(patient);
        var patientDto = _mapper.Map<Patient, PatientDto>(patient);
        result.Add(patientDto, validationResult);

        if (validationResult.IsValid)
          await _patientService.SaveAsync(patient.Name, patient.Surname, patient.Pesel, patient.Email);
        else
        {
          foreach (var error in validationResult.Errors)
          {
            _log.Warn(error);
          }
        }
        _log.InfoFormat("Wczytano pacjenta z pliku CSV : " +
                        "PESEL: {0}, " +
                        "Imię: {1}, " +
                        "Nazwisko: {2}," +
                        "Email: {3}", patientDto.Pesel, patientDto.Name, patientDto.Surname, patientDto.Email);
      }

      _log.Info("Zakończono wczytywanie pliku CSV.");

      return result;
    }
  }
}