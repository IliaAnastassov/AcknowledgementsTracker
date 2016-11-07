namespace AcknowledgementsTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddNormalizedTextProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Acknowledgements", "NormalizedText", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Acknowledgements", "NormalizedText");
        }
    }
}
