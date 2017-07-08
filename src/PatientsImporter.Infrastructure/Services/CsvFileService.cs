using System.Collections.Generic;
using System.IO;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using PatientsImporter.Core.Domain;
using PatientsImporter.Infrastructure.CsvClassMap;

namespace PatientsImporter.Infrastructure.Services
{
  public class CsvFileService : ICsvFileService
  {
    private readonly IMapper _mapper;

    public CsvFileService(IMapper mapper)
    {
      _mapper = mapper;
    }

    public IEnumerable<Patient> LoadPatients(TextReader file)
    {
      var result = new List<Patient>();
      var configuration = new CsvConfiguration
      {
        Delimiter = ";",
        IgnoreHeaderWhiteSpace = true
      };
      using (var csvReader = new CsvReader(file, configuration))
      {
        csvReader.Configuration.RegisterClassMap<PatientCsvClassMap>();

        var patientsCsv = csvReader.GetRecords<PatientCsv>();
        foreach (var patientCsv in patientsCsv)
        {
          var patient = _mapper.Map<PatientCsv, Patient>(patientCsv);
          result.Add(patient);
        }

        return result;
      }
    }
  }
}