namespace ConsoleApplication
{
    using System;
    using System.Data.Entity;
    using AcknowledgementsTracker.Buisiness.Models;
    using AcknowledgementsTracker.DataAccess;

    class Startup
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<AcknowledgementsTrackerContext>());

            var modelManager = new ModelManager();
            ////modelManager.CreateProxiadEmployee("shmuleyB", "shmuley@proxiad.com");
            ////modelManager.CreateTag("mvvm");
            modelManager.CreateAcknowledgement("Thanks bro!", 1);
        }
    }
}
