using System.Collections.Generic;
using System.IO;
using FluentValidation.Results;
using PatientsImporter.Core.Domain;

namespace PatientsImporter.Infrastructure.Services
{
  public interface ICsvFileService : IService
  {
    IEnumerable<Patient> LoadPatients(TextReader file);
  }
}