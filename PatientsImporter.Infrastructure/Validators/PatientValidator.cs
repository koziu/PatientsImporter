using FluentValidation;
using PatientsImporter.Core.Domain;
using PatientsImporter.Infrastructure.Const;
using PatientsImporter.Infrastructure.ExtensionMethods;

namespace PatientsImporter.Infrastructure.Validators
{
  public class PatientValidator : AbstractValidator<Patient>
  {
    public PatientValidator()
    {
      RuleFor(patient => patient.Name).NotNull().WithMessage(ValidationMessages.NameNotNull);
      RuleFor(patient => patient.Surname).NotNull().WithMessage(ValidationMessages.SurnameNotNull);
      RuleFor(patient => patient.Email).Matches(Regexs.EmailRegex).WithMessage(ValidationMessages.EmailFormatValid);
      RuleFor(patient => patient.Pesel)
        .Must(pesel => pesel.IsValidPesel())
        .WithMessage(ValidationMessages.PeselFormatValid);
    }
  }
}