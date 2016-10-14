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
                if (context.Acknowledgements.Any() || context.Tags.Any())
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

                // ACKNOWLEDGEMENTS
                var acknowledgementOne = new Acknowledgement()
                {
                    Text = "Thank you for making it rain all weekend. Biatch.",
                    AuthorUsername = "magneto@proxiad.com",
                    BeneficiaryUsername = "storm@proxiad.com",
                    Tags = new List<Tag> { weatherTag }
                };

                var acknowledgementTwo = new Acknowledgement()
                {
                    Text = "Thanks for being such an asshole and stealing my bike. If you don't give it back to me in one peace I'll kick your magnetic ass!",
                    AuthorUsername = "wolverine@proxiad.com",
                    BeneficiaryUsername = "magneto@proxiad.com",
                    Tags = new List<Tag> { theftTag, fightTag }
                };

                var acknowledgementThree = new Acknowledgement()
                {
                    Text = "When I was depressed you were there for me. We had such a nice time drinking till collapse.",
                    AuthorUsername = "profesorX@proxiad.com",
                    BeneficiaryUsername = "wolverin@proxiad.come",
                    Tags = new List<Tag> { drinkingTag }
                };

                var acknowledgementFour = new Acknowledgement()
                {
                    Text = "Thanks for impersonating me and making it rain all weekend. Now everyone HATES ME because of you!",
                    AuthorUsername = "storm@proxiad.com",
                    BeneficiaryUsername = "mystique@proxiad.com",
                    Tags = new List<Tag> { weatherTag, theftTag }
                };

                context.Acknowledgements.AddOrUpdate(acknowledgementOne, acknowledgementTwo, acknowledgementThree, acknowledgementFour);

                context.SaveChanges();
            }
        }
    }
}
