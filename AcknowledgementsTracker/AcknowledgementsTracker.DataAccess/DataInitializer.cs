// <copyright file="DataInitializer.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Model.Models;

    public class DataInitializer
    {
        public void InitializeData()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AcknowledgementsTrackerContext>());

            using (var context = new AcknowledgementsTrackerContext())
            {
                if (context.Acknowledgements.Any() || context.Tags.Any() || context.ProxiadEmployees.Any())
                {
                    return;
                }

                var csharpTag = new Tag()
                {
                    Title = "c#",
                };

                var aspnetTag = new Tag()
                {
                    Title = "asp.net"
                };

                var atlasTag = new Tag()
                {
                    Title = "atlas"
                };

                var nugetTag = new Tag()
                {
                    Title = "nuget"
                };

                var wolverine = new ProxiadEmployee()
                {
                    UserName = "wolverine",
                    Email = "wolverine@proxiad.com"
                };

                var magneto = new ProxiadEmployee()
                {
                    UserName = "Magneto",
                    Email = "magneto@proxiad.com"
                };

                var storm = new ProxiadEmployee()
                {
                    UserName = "storm",
                    Email = "storm@proxiad.com"
                };

                var acknowledgementOne = new Acknowledgement()
                {
                    Text = "Thank you for your help",
                    // TODO:
                };
            }
        }
    }
}
