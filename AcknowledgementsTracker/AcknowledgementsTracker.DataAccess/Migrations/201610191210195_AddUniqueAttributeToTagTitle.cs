namespace AcknowledgementsTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueAttributeToTagTitle : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tags", "Title", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tags", new[] { "Title" });
        }
    }
}
