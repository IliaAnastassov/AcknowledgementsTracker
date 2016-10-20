// <copyright file="TagsRepository.cs" company="Proxiad Bulgaria">
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
    using Assembler;
    using Context;
    using DTO;
    using Interfaces;
    using Model;

    public class TagsRepository : IRepository<TagDTO>
    {
        private TagDtoAssembler assembler = new TagDtoAssembler();

        public TagDTO Get(string title)
        {
            Tag tag;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                tag = context.Tags.AsNoTracking().Where(t => t.Title == title).FirstOrDefault();
            }

            return assembler.Assemble(tag);
        }

        public TagDTO Get(int id)
        {
            Tag tag;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                tag = context.Tags.Find(id);
            }

            return assembler.Assemble(tag);
        }

        public IEnumerable<TagDTO> GetAcknowledgementTags(int acknowledgementId)
        {
            IEnumerable<Tag> tags;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var acknowledgement = context.Acknowledgements.Find(acknowledgementId);
                tags = acknowledgement.Tags;
            }

            return assembler.AssembleCollection(tags);
        }

        public IEnumerable<TagDTO> GetAll()
        {
            IEnumerable<Tag> tags;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                tags = context.Tags.ToList();
            }

            return assembler.AssembleCollection(tags);
        }

        // TODO: Is this method really necessary?
        public void Add(TagDTO tagDto)
        {
            var tag = assembler.Disassemble(tagDto);

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Tags.Add(tag);
                context.SaveChanges();
            }
        }

        public void Edit(TagDTO tagDto)
        {
            var tag = assembler.Disassemble(tagDto);

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Entry(tag).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Remove(int id)
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
