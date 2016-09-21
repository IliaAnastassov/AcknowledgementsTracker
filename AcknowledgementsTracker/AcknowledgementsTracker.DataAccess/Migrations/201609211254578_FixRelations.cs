namespace AcknowledgementsTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FixRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Acknowledgements", "ProxiadEmployeeId", "dbo.ProxiadEmployees");
            DropForeignKey("dbo.TagAcknowledgements", "Acknowledgement_Id", "dbo.Acknowledgements");
            DropForeignKey("dbo.TagAcknowledgements", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.Acknowledgements", new[] { "ProxiadEmployeeId" });
            DropPrimaryKey("dbo.Acknowledgements");
            DropPrimaryKey("dbo.Tags");
            RenameColumn(table: "dbo.TagAcknowledgements", name: "Tag_Id", newName: "Tag_TagId");
            RenameColumn(table: "dbo.TagAcknowledgements", name: "Acknowledgement_Id", newName: "Acknowledgement_AcknowledgementId");
            RenameIndex(table: "dbo.TagAcknowledgements", name: "IX_Tag_Id", newName: "IX_Tag_TagId");
            RenameIndex(table: "dbo.TagAcknowledgements", name: "IX_Acknowledgement_Id", newName: "IX_Acknowledgement_AcknowledgementId");
            CreateTable(
                "dbo.Employees",
                c => new
                {
                    EmployeeId = c.Int(nullable: false, identity: true),
                    UserName = c.String(nullable: false, maxLength: 50),
                    Email = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.EmployeeId);

            DropTable("dbo.ProxiadEmployees");
            DropColumn("dbo.Acknowledgements", "Id");
            DropColumn("dbo.Acknowledgements", "ProxiadEmployeeId");
            DropColumn("dbo.Tags", "Id");
            AddColumn("dbo.Acknowledgements", "AcknowledgementId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Acknowledgements", "AuthorId", c => c.Int(nullable: false));
            AddColumn("dbo.Acknowledgements", "BeneficiaryId", c => c.Int(nullable: false));
            AddColumn("dbo.Tags", "TagId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Acknowledgements", "Text", c => c.String(nullable: false, maxLength: 1500));
            AlterColumn("dbo.Tags", "Title", c => c.String(nullable: false, maxLength: 100));
            AddPrimaryKey("dbo.Acknowledgements", "AcknowledgementId");
            AddPrimaryKey("dbo.Tags", "TagId");
            CreateIndex("dbo.Acknowledgements", "AuthorId");
            CreateIndex("dbo.Acknowledgements", "BeneficiaryId");
            AddForeignKey("dbo.Acknowledgements", "AuthorId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.Acknowledgements", "BeneficiaryId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.TagAcknowledgements", "Acknowledgement_AcknowledgementId", "dbo.Acknowledgements", "AcknowledgementId", cascadeDelete: true);
            AddForeignKey("dbo.TagAcknowledgements", "Tag_TagId", "dbo.Tags", "TagId", cascadeDelete: true);
        }

        public override void Down()
        {
            CreateTable(
                "dbo.ProxiadEmployees",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserName = c.String(),
                    Email = c.String(),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Tags", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Acknowledgements", "ProxiadEmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Acknowledgements", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.TagAcknowledgements", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.TagAcknowledgements", "Acknowledgement_AcknowledgementId", "dbo.Acknowledgements");
            DropForeignKey("dbo.Acknowledgements", "BeneficiaryId", "dbo.Employees");
            DropForeignKey("dbo.Acknowledgements", "AuthorId", "dbo.Employees");
            DropIndex("dbo.Acknowledgements", new[] { "BeneficiaryId" });
            DropIndex("dbo.Acknowledgements", new[] { "AuthorId" });
            DropPrimaryKey("dbo.Tags");
            DropPrimaryKey("dbo.Acknowledgements");
            AlterColumn("dbo.Tags", "Title", c => c.String());
            AlterColumn("dbo.Acknowledgements", "Text", c => c.String());
            DropColumn("dbo.Tags", "TagId");
            DropColumn("dbo.Acknowledgements", "BeneficiaryId");
            DropColumn("dbo.Acknowledgements", "AuthorId");
            DropColumn("dbo.Acknowledgements", "AcknowledgementId");
            DropTable("dbo.Employees");
            AddPrimaryKey("dbo.Tags", "Id");
            AddPrimaryKey("dbo.Acknowledgements", "Id");
            RenameIndex(table: "dbo.TagAcknowledgements", name: "IX_Acknowledgement_AcknowledgementId", newName: "IX_Acknowledgement_Id");
            RenameIndex(table: "dbo.TagAcknowledgements", name: "IX_Tag_TagId", newName: "IX_Tag_Id");
            RenameColumn(table: "dbo.TagAcknowledgements", name: "Acknowledgement_AcknowledgementId", newName: "Acknowledgement_Id");
            RenameColumn(table: "dbo.TagAcknowledgements", name: "Tag_TagId", newName: "Tag_Id");
            CreateIndex("dbo.Acknowledgements", "ProxiadEmployeeId");
            AddForeignKey("dbo.TagAcknowledgements", "Tag_Id", "dbo.Tags", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TagAcknowledgements", "Acknowledgement_Id", "dbo.Acknowledgements", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Acknowledgements", "ProxiadEmployeeId", "dbo.ProxiadEmployees", "Id", cascadeDelete: true);
        }
    }
}
