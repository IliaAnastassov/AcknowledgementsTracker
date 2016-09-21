// <copyright file="DataInitializer.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.DataAccess.Migrations
{
    using System.Linq;
    using Model;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Context;

    public class DataInitializer
    {
        public void InitializeData()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                if (context.Acknowledgements.Any() || context.Tags.Any() || context.Employees.Any())
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
                var wolverine = new Employee()
                {
                    UserName = "wolverine",
                    Email = "wolverine@xmen.com"
                };

                var magneto = new Employee()
                {
                    UserName = "Magneto",
                    Email = "magneto@xmen.com"
                };

                var storm = new Employee()
                {
                    UserName = "storm",
                    Email = "storm@xmen.com"
                };

                var mystique = new Employee()
                {
                    UserName = "mystique",
                    Email = "mystique@xmen.com"
                };

                var profesorX = new Employee()
                {
                    UserName = "professorX",
                    Email = "professorX@xmen.com"
                };

                context.Employees.AddOrUpdate(wolverine, magneto, storm, mystique, profesorX);

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
                    Text = "Thanks for being such an asshole and stealing my bike. If you don't give it back to me in one peace I'll kick your magnetic ass!",
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
