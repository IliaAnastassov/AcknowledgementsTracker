﻿// <copyright file="TagsRepository.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;
    using Context;
    using Interfaces;
    using Model;

    public class TagsRepository : ITagsRepository
    {
        public List<Tag> GetTags()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.Tags.ToList();
            }
        }

        public Tag GetTag(int id)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.Tags.Find(id);
            }
        }

        public void SaveTag(string title)
        {
            var tag = new Tag()
            {
                Title = $"#{title}"
            };

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Tags.Add(tag);
                context.SaveChanges();
            }
        }

        public void EditTag(Tag tag)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Entry(tag).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteTag(int id)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Entry(context.Tags.Find(id)).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
