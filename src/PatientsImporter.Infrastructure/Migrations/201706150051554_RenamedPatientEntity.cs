namespace PatientsImporter.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedPatientEntity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PatientModels", newName: "Patient");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Patient", newName: "PatientModels");
        }
    }
}
