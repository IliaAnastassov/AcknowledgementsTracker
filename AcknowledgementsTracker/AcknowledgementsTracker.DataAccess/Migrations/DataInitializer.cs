// <copyright file="DataInitializer.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Model.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public class DataInitializer
    {
        public void InitializeData()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                if (context.Acknowledgements.Any() || context.Tags.Any() || context.ProxiadEmployees.Any())
                {
                    return;
                }

                // TAGS
                var weatherTag = new Tag()
                {
                    Title = "weather",
                };

                var theftTag = new Tag()
                {
                    Title = "theft"
                };

                var drinkingTag = new Tag()
                {
                    Title = "drink"
                };

                var fightTag = new Tag()
                {
                    Title = "fight"
                };

                context.Tags.AddOrUpdate(weatherTag, theftTag, drinkingTag, fightTag);

                // EMPLOYEES
                var wolverine = new ProxiadEmployee()
                {
                    UserName = "wolverine",
                    Email = "wolverine@xmen.com"
                };

                var magneto = new ProxiadEmployee()
                {
                    UserName = "Magneto",
                    Email = "magneto@xmen.com"
                };

                var storm = new ProxiadEmployee()
                {
                    UserName = "storm",
                    Email = "storm@xmen.com"
                };

                var mystique = new ProxiadEmployee()
                {
                    UserName = "mystique",
                    Email = "mystique@xmen.com"
                };

                var profesorX = new ProxiadEmployee()
                {
                    UserName = "professorX",
                    Email = "professorX@xmen.com"
                };

                context.ProxiadEmployees.AddOrUpdate(wolverine, magneto, storm, mystique, profesorX);

                // ACKNOWLEDGEMENTS
                var acknowledgementOne = new Acknowledgement()
                {
                    Text = "Thank you for making it rain all weekend. Biatch.",
                    Author = magneto,
                    Beneficiary = storm,
                    Tags = new List<Tag> { weatherTag }
                };

                var acknowledgementTwo = new Acknowledgement()
                {
                    Text = "Thanks for being such an asshole and stealing my bike. If you don't give it back to me in one peace I'll kick your butt!",
                    Author = wolverine,
                    Beneficiary = magneto,
                    Tags = new List<Tag> { theftTag, fightTag }
                };

                var acknowledgementThree = new Acknowledgement()
                {
                    Text = "When I was depressed you were there for me. We had such a nice time drinking till collapse.",
                    Author = profesorX,
                    Beneficiary = wolverine,
                    Tags = new List<Tag> { drinkingTag }
                };

                var acknowledgementFour = new Acknowledgement()
                {
                    Text = "Thanks for impersonating me and making it rain all weekend. Now everyone HATES ME because of you!",
                    Author = storm,
                    Beneficiary = mystique,
                    Tags = new List<Tag> { weatherTag, theftTag }
                };

                context.Acknowledgements.AddOrUpdate(acknowledgementOne, acknowledgementTwo, acknowledgementThree, acknowledgementFour);

                context.SaveChanges();
            }
        }
    }
}
