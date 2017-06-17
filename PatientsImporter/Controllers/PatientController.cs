using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PatientsImporter.Conventers;
using PatientsImporter.Infrastructure.Dto;
using PatientsImporter.Infrastructure.Services;
using PatientsImporter.Models.Patients;

namespace PatientsImporter.Controllers
{
  public class PatientController : Controller
  {
    private readonly IPatientService _patientService;
    private readonly IUploadService _uploadService;
    private readonly IConventer<IEnumerable<PatientDto>, IEnumerable<PatientViewModel>> _patientsConventer;
    


    public PatientController(IPatientService patientService, IUploadService uploadService, IConventer<IEnumerable<PatientDto>, IEnumerable<PatientViewModel>> patientsConventer)
    {
      _patientService = patientService;
      _uploadService = uploadService;
      _patientsConventer = patientsConventer;
    }

    public async Task<ActionResult> Index()
    {
      var patientsDto = await _patientService.GetAllAsync();
      var patientDto = patientsDto as IList<PatientDto> ?? patientsDto.ToList();
      if (patientDto.Any())
      {
        var patientsViewModels = _patientsConventer.Convert(patientDto);
        return View(patientsViewModels);
      }

      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Upload(HttpPostedFileBase file)
    {
      if (ModelState.IsValid)
      {
        var result = await _uploadService.UploadPatientsAsync(file);
      }

      return RedirectToAction("Index");
    }
  }
}