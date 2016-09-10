namespace ConsoleApplication
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using AcknowledgementsTracker.Buisiness.Models;
    using AcknowledgementsTracker.DataAccess;

    class Startup
    {
        // TODO: Make the many to many relationship work (Acknowledgement - Tag)
        static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<AcknowledgementsTrackerContext>());

            var modelManager = new ModelManager();
            ////modelManager.CreateProxiadEmployee("shmuleyB", "shmuley@proxiad.com");
            ////modelManager.CreateTag("mvvm");
            modelManager.CreateAcknowledgement("Thanks bro!", 2, new List<int> { 1, 3 });
        }
    }
}
