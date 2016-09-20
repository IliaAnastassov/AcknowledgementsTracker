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
    using DTO.Interfaces;
    using Interfaces;
    using Model;

    public class TagsRepository : IRepository<IDto>
    {
        private TagDtoAssembler assembler = new TagDtoAssembler();

        public IDto Get(int id)
        {
            Tag tag;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                tag = context.Tags.Find(id);
            }

            return assembler.Assemble(tag);
        }

        public IEnumerable<IDto> GetAll()
        {
            IEnumerable<Tag> tags;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                tags = context.Tags.ToList();
            }

            return assembler.AssembleCollection(tags);
        }

        public void Save(IDto tagDto)
        {
            var tag = assembler.Disassemble((TagDTO)tagDto);

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Tags.Add(tag);
                context.SaveChanges();
            }
        }

        public void Edit(IDto tagDto)
        {
            var tag = assembler.Disassemble((TagDTO)tagDto);

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Entry(tag).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
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
