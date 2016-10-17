namespace AcknowledgementsTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RemoveEmployeeEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Acknowledgements", "AuthorId", "dbo.Employees");
            DropForeignKey("dbo.Acknowledgements", "BeneficiaryId", "dbo.Employees");
            DropIndex("dbo.Acknowledgements", new[] { "AuthorId" });
            DropIndex("dbo.Acknowledgements", new[] { "BeneficiaryId" });
            AddColumn("dbo.Acknowledgements", "AuthorUsername", c => c.String());
            AddColumn("dbo.Acknowledgements", "BeneficiaryUsername", c => c.String());
            DropColumn("dbo.Acknowledgements", "AuthorId");
            DropColumn("dbo.Acknowledgements", "BeneficiaryId");
            DropTable("dbo.Employees");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                {
                    EmployeeId = c.Int(nullable: false, identity: true),
                    UserName = c.String(nullable: false, maxLength: 50),
                    Email = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.EmployeeId);

            AddColumn("dbo.Acknowledgements", "BeneficiaryId", c => c.Int(nullable: false));
            AddColumn("dbo.Acknowledgements", "AuthorId", c => c.Int(nullable: false));
            DropColumn("dbo.Acknowledgements", "BeneficiaryUsername");
            DropColumn("dbo.Acknowledgements", "AuthorUsername");
            CreateIndex("dbo.Acknowledgements", "BeneficiaryId");
            CreateIndex("dbo.Acknowledgements", "AuthorId");
            AddForeignKey("dbo.Acknowledgements", "BeneficiaryId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.Acknowledgements", "AuthorId", "dbo.Employees", "EmployeeId");
        }
    }
}
