namespace ConsoleApplication
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using AcknowledgementsTracker.DataAccess;

    class Startup
    {
        // TODO: Implement Repository Pattern
        // TODO: Make the many to many relationship work (Acknowledgement - Tag)
        static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<AcknowledgementsTrackerContext>());

        }
    }
}
