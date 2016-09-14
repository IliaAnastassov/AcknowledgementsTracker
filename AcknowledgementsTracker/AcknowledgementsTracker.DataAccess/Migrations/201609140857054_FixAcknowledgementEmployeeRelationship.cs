namespace AcknowledgementsTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAcknowledgementEmployeeRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Acknowledgements", "ProxiadEmployeeId", "dbo.ProxiadEmployees");
            RenameColumn(table: "dbo.Acknowledgements", name: "ProxiadEmployeeId", newName: "AuthorId");
            RenameIndex(table: "dbo.Acknowledgements", name: "IX_ProxiadEmployeeId", newName: "IX_AuthorId");
            AddColumn("dbo.Acknowledgements", "BeneficiaryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Acknowledgements", "Text", c => c.String(nullable: false, maxLength: 1500));
            AlterColumn("dbo.ProxiadEmployees", "UserName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ProxiadEmployees", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tags", "Title", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Acknowledgements", "BeneficiaryId");
            AddForeignKey("dbo.Acknowledgements", "BeneficiaryId", "dbo.ProxiadEmployees", "Id");
            AddForeignKey("dbo.Acknowledgements", "AuthorId", "dbo.ProxiadEmployees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Acknowledgements", "AuthorId", "dbo.ProxiadEmployees");
            DropForeignKey("dbo.Acknowledgements", "BeneficiaryId", "dbo.ProxiadEmployees");
            DropIndex("dbo.Acknowledgements", new[] { "BeneficiaryId" });
            AlterColumn("dbo.Tags", "Title", c => c.String());
            AlterColumn("dbo.ProxiadEmployees", "Email", c => c.String());
            AlterColumn("dbo.ProxiadEmployees", "UserName", c => c.String());
            AlterColumn("dbo.Acknowledgements", "Text", c => c.String());
            DropColumn("dbo.Acknowledgements", "BeneficiaryId");
            RenameIndex(table: "dbo.Acknowledgements", name: "IX_AuthorId", newName: "IX_ProxiadEmployeeId");
            RenameColumn(table: "dbo.Acknowledgements", name: "AuthorId", newName: "ProxiadEmployeeId");
            AddForeignKey("dbo.Acknowledgements", "ProxiadEmployeeId", "dbo.ProxiadEmployees", "Id", cascadeDelete: true);
        }
    }
}
