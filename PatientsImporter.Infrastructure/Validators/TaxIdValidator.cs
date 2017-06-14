using System.Text.RegularExpressions;
using FluentValidation;
using PatientsImporter.Core.Domain;
using PatientsImporter.Infrastructure.Const;
using PatientsImporter.Infrastructure.ExtensionMethods;

namespace PatientsImporter.Infrastructure.Validators
{
  public class TaxIdValidator : AbstractValidator<Patient>
  {
    public TaxIdValidator()
    {
      RuleFor(patient => patient.Name).NotNull().WithMessage(ValidationMessages.NameNotNull);
      RuleFor(patient => patient.Surname).NotNull().WithMessage(ValidationMessages.SurnameNotNull);
      RuleFor(patient => patient.Email).Matches(Regexs.EmailRegex).WithMessage(ValidationMessages.EmailFormatValid);
      RuleFor(patient => patient.TaxId).Must(taxId => taxId.IsValidTaxId()).WithMessage(ValidationMessages.TaxIdFormatValid);
    }
  }
}