using System.Data.Entity;
using PatientsImporter.Core.Domain;
using PatientsImporter.Infrastructure.DbModels;

namespace PatientsImporter.Infrastructure.DBContext
{
  public class PatientnsImporterContext : DbContext
  {
    public PatientnsImporterContext() : base("PatientnsImporter")
    {
      
    }
    public DbSet<PatientModel> Patient { get; set; }
  }
}