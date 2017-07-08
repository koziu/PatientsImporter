namespace PatientsImporter.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePatientEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientModels",
                c => new
                    {
                        TaxId = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.TaxId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PatientModels");
        }
    }
}
