namespace AcknowledgementsTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddGivenReceivedSplit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Acknowledgements", "ProxiadEmployeeId", "dbo.ProxiadEmployees");
            DropIndex("dbo.Acknowledgements", new[] { "ProxiadEmployeeId" });
            RenameColumn(table: "dbo.Acknowledgements", name: "ProxiadEmployeeId", newName: "ProxiadEmployee_Id");
            AddColumn("dbo.Acknowledgements", "AuthorId", c => c.Int(nullable: false));
            AddColumn("dbo.Acknowledgements", "BeneficiaryId", c => c.Int(nullable: false));
            AddColumn("dbo.Acknowledgements", "ProxiadEmployee_Id1", c => c.Int());
            AlterColumn("dbo.Acknowledgements", "Text", c => c.String(maxLength: 1500));
            AlterColumn("dbo.Acknowledgements", "ProxiadEmployee_Id", c => c.Int());
            AlterColumn("dbo.ProxiadEmployees", "UserName", c => c.String(maxLength: 50));
            AlterColumn("dbo.ProxiadEmployees", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Tags", "Title", c => c.String(maxLength: 100));
            CreateIndex("dbo.Acknowledgements", "AuthorId");
            CreateIndex("dbo.Acknowledgements", "BeneficiaryId");
            CreateIndex("dbo.Acknowledgements", "ProxiadEmployee_Id");
            CreateIndex("dbo.Acknowledgements", "ProxiadEmployee_Id1");
            AddForeignKey("dbo.Acknowledgements", "ProxiadEmployee_Id1", "dbo.ProxiadEmployees", "Id");
            AddForeignKey("dbo.Acknowledgements", "AuthorId", "dbo.ProxiadEmployees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Acknowledgements", "BeneficiaryId", "dbo.ProxiadEmployees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Acknowledgements", "ProxiadEmployee_Id", "dbo.ProxiadEmployees", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Acknowledgements", "ProxiadEmployee_Id", "dbo.ProxiadEmployees");
            DropForeignKey("dbo.Acknowledgements", "BeneficiaryId", "dbo.ProxiadEmployees");
            DropForeignKey("dbo.Acknowledgements", "AuthorId", "dbo.ProxiadEmployees");
            DropForeignKey("dbo.Acknowledgements", "ProxiadEmployee_Id1", "dbo.ProxiadEmployees");
            DropIndex("dbo.Acknowledgements", new[] { "ProxiadEmployee_Id1" });
            DropIndex("dbo.Acknowledgements", new[] { "ProxiadEmployee_Id" });
            DropIndex("dbo.Acknowledgements", new[] { "BeneficiaryId" });
            DropIndex("dbo.Acknowledgements", new[] { "AuthorId" });
            AlterColumn("dbo.Tags", "Title", c => c.String());
            AlterColumn("dbo.ProxiadEmployees", "Email", c => c.String());
            AlterColumn("dbo.ProxiadEmployees", "UserName", c => c.String());
            AlterColumn("dbo.Acknowledgements", "ProxiadEmployee_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Acknowledgements", "Text", c => c.String());
            DropColumn("dbo.Acknowledgements", "ProxiadEmployee_Id1");
            DropColumn("dbo.Acknowledgements", "BeneficiaryId");
            DropColumn("dbo.Acknowledgements", "AuthorId");
            RenameColumn(table: "dbo.Acknowledgements", name: "ProxiadEmployee_Id", newName: "ProxiadEmployeeId");
            CreateIndex("dbo.Acknowledgements", "ProxiadEmployeeId");
            AddForeignKey("dbo.Acknowledgements", "ProxiadEmployeeId", "dbo.ProxiadEmployees", "Id", cascadeDelete: true);
        }
    }
}
