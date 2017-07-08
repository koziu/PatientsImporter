using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientsImporter.Infrastructure.DbModels
{
  [Table("Patient")]
  public class PatientModel
  {
    [Key]
    public string Pesel { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
  }
}