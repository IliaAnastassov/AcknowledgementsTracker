// <copyright file="Configuration.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    using Context;

    internal sealed class Configuration : DbMigrationsConfiguration<AcknowledgementsTrackerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AcknowledgementsTrackerContext context)
        {
            // This method will be called after migrating to the latest version
        }
    }
}
