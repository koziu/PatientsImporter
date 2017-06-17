using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using log4net;
using PatientsImporter.Core.Domain;
using PatientsImporter.Core.Repositories;
using PatientsImporter.Infrastructure.DbModels;
using PatientsImporter.Infrastructure.DBContext;

namespace PatientsImporter.Infrastructure.Repositories
{
  public class InMsDbPatientRepository : IPatientRepository, IDisposable
  {
    private readonly PatientnsImporterContext _context;
    private readonly IMapper _mapper;
    private readonly ILog _log;

    public InMsDbPatientRepository(PatientnsImporterContext context, IMapper mapper, ILog logr)
    {
      _context = context;
      _mapper = mapper;
      _log = logr;
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
      _log.Info("Pobieranie wszystkich pajcentów.");
      var patients = await _context.Patient.ToListAsync();
      return await Task.FromResult(_mapper.Map<IEnumerable<PatientModel>, IEnumerable<Patient>>(patients));
    }

    public async Task<Patient> GetAsync(string pesel)
    {
      _log.InfoFormat("Pobieranie pacjenta o nipie {1}", pesel);
      var patient = _context.Patient.SingleOrDefault(x => x.Pesel == pesel);
      return await Task.FromResult(_mapper.Map<PatientModel, Patient>(patient));
    }

    public async Task AddAsync(Patient patient)
    {
      _log.Info("Zapisywanie pacjenta.");
      var patientDbModel = (_mapper.Map<Patient, PatientModel>(patient));
      _context.Patient.Add(patientDbModel);
      await _context.SaveChangesAsync();
      _log.InfoFormat("Zapisano pacjenta: " +
                     "PESEL: {0}, " +
                     "Imię: {1}, " +
                     "Nazwisko: {2}," +
                     "Email: {3}", patient.Pesel, patient.Name, patient.Surname, patient.Email);
    }

    public void Dispose()
    {
      _context?.Dispose();
    }
  }
}