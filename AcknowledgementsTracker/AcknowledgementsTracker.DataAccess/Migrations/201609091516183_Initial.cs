namespace AcknowledgementsTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acknowledgements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        ProxiadEmployeeId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProxiadEmployees", t => t.ProxiadEmployeeId, cascadeDelete: true)
                .Index(t => t.ProxiadEmployeeId);
            
            CreateTable(
                "dbo.ProxiadEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagAcknowledgements",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Acknowledgement_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Acknowledgement_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Acknowledgements", t => t.Acknowledgement_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Acknowledgement_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagAcknowledgements", "Acknowledgement_Id", "dbo.Acknowledgements");
            DropForeignKey("dbo.TagAcknowledgements", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Acknowledgements", "ProxiadEmployeeId", "dbo.ProxiadEmployees");
            DropIndex("dbo.TagAcknowledgements", new[] { "Acknowledgement_Id" });
            DropIndex("dbo.TagAcknowledgements", new[] { "Tag_Id" });
            DropIndex("dbo.Acknowledgements", new[] { "ProxiadEmployeeId" });
            DropTable("dbo.TagAcknowledgements");
            DropTable("dbo.Tags");
            DropTable("dbo.ProxiadEmployees");
            DropTable("dbo.Acknowledgements");
        }
    }
}
