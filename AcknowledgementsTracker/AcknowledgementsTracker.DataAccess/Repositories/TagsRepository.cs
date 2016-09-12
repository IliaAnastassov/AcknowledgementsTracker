namespace AcknowledgementsTracker.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;
    using Model.Models;

    public class TagsRepository
    {
        public void SaveTag(string title)
        {
            var tag = new Tag()
            {
                // Possible change
                Title = $"#{title}"
            };

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Tags.Add(tag);
                context.SaveChanges();
            }
        }

        public void EditTag()
        {
            // TODO:
        }

        public void DeleteTag()
        {
            // TODO:
        }
    }
}
