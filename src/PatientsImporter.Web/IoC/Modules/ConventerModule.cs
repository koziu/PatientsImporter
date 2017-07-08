using System.Collections.Generic;
using Autofac;
using PatientsImporter.Conventers;
using PatientsImporter.Infrastructure.Dto;
using PatientsImporter.Models.Patients;

namespace PatientsImporter.IoC.Modules
{
  public class ConventerModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<PatientDtoToViewModelConventer>().As<IConventer<PatientDto, PatientViewModel>>();
      builder.RegisterType<PatientsDtoToViewModelsConventer>()
        .As<IConventer<IEnumerable<PatientDto>, IEnumerable<PatientViewModel>>>();
    }
  }
}