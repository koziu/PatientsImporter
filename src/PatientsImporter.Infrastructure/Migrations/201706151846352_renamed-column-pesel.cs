namespace PatientsImporter.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedcolumnpesel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Patient");
            AddColumn("dbo.Patient", "Pesel", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Patient", "Pesel");
            DropColumn("dbo.Patient", "TaxId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patient", "TaxId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Patient");
            DropColumn("dbo.Patient", "Pesel");
            AddPrimaryKey("dbo.Patient", "TaxId");
        }
    }
}
