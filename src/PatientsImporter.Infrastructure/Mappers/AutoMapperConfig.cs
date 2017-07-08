using System.Collections.Generic;
using AutoMapper;
using PatientsImporter.Core.Domain;
using PatientsImporter.Infrastructure.CsvClassMap;
using PatientsImporter.Infrastructure.DbModels;
using PatientsImporter.Infrastructure.Dto;

namespace PatientsImporter.Infrastructure.Mappers
{
  public class AutoMapperConfig
  {
    public static IMapper Initialize()
      => new MapperConfiguration(config =>
      {
        config.CreateMap<Patient, PatientDto>();
        config.CreateMap<PatientModel, Patient>();
        config.CreateMap<PatientCsv, Patient>();
        config.CreateMap<Patient, PatientModel> ();
      }).CreateMapper();
  }
}