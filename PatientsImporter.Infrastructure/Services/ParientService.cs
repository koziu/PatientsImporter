using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using PatientsImporter.Core.Domain;
using PatientsImporter.Core.Repositories;
using PatientsImporter.Infrastructure.Dto;

namespace PatientsImporter.Infrastructure.Services
{
  public class ParientService : IPatientService
  {
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<Patient> _patientValidator;

    public ParientService(IPatientRepository patientRepository, IMapper mapper, IValidator<Patient> patientValidator)
    {
      _patientRepository = patientRepository;
      _mapper = mapper;
      _patientValidator = patientValidator;
    }

    public async Task<IEnumerable<PatientDto>> GetAllAsync()
    {
      var patients = await _patientRepository.GetAllAsync();

      return _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientDto>>(patients);
    }

    public async Task<PatientDto> GetAsync(string taxId)
    {
      var patient = await _patientRepository.GetAsync(taxId);

      return _mapper.Map<Patient, PatientDto>(patient);
    }

    public async Task SaveAsync(string name, string surname, string taxId, string email)
    {
      var patient = await _patientRepository.GetAsync(taxId);

      if (patient != null)
        return;

      patient = new Patient(name, surname, taxId, email);
      var validationResult = await _patientValidator.ValidateAsync(patient);
      if (!validationResult.IsValid)
        return;
      await _patientRepository.AddAsync(patient);
    }
  }
}