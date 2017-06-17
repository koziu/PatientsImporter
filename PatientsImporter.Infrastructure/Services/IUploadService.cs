using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web;
using FluentValidation.Results;
using PatientsImporter.Infrastructure.Dto;

namespace PatientsImporter.Infrastructure.Services
{
  public interface IUploadService : IService
  {
    Task<IDictionary<PatientDto, ValidationResult>> UploadPatientsAsync(HttpPostedFileBase file);
  }
}