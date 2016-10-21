// <copyright file="AcknowledgementsRepository.cs" company="Proxiad Bulgaria">
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
    using Assembler.Interfaces;
    using Context;
    using DTO;
    using Interfaces;
    using Model;

    public class AcknowledgementsRepository : IRepository<AcknowledgementDTO>
    {
        private IAssembler<Acknowledgement, AcknowledgementDTO> assembler = new AcknowledgementDtoAssembler();
        private TagsRepository tagsRepo = new TagsRepository();

        public AcknowledgementDTO Get(int id)
        {
            Acknowledgement acknowledgement;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                acknowledgement = context.Acknowledgements.Find(id);
            }

            return assembler.Assemble(acknowledgement);
        }

        public IEnumerable<AcknowledgementDTO> GetAll()
        {
            IEnumerable<Acknowledgement> acknowledgements;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                acknowledgements = context.Acknowledgements.ToList();
            }

            return assembler.AssembleCollection(acknowledgements);
        }

        public IEnumerable<AcknowledgementDTO> GetAcknowledgements(string username)
        {
            IEnumerable<Acknowledgement> acknowledgements;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                acknowledgements = context.Acknowledgements.AsNoTracking().Include(a => a.Tags)
                    .Where(a => a.BeneficiaryUsername == username).OrderByDescending(a => a.DateCreated).ToList();
            }

            return assembler.AssembleCollection(acknowledgements);
        }

        public IEnumerable<AcknowledgementDTO> GetTodaysAcknowledgements()
        {
            IEnumerable<Acknowledgement> acknowledgements;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                acknowledgements = context.Acknowledgements.AsNoTracking().Include(a => a.Tags)
                    .Where(a => a.DateCreated.Year == DateTime.Today.Year &&
                                a.DateCreated.Month == DateTime.Today.Month &&
                                a.DateCreated.Day == DateTime.Today.Day).OrderByDescending(a => a.DateCreated).ToList();
            }

            return assembler.AssembleCollection(acknowledgements);
        }

        public IEnumerable<AcknowledgementDTO> GetThisWeekAcknowledgements()
        {
            IEnumerable<Acknowledgement> acknowledgements;
            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1),
                endOfWeek = startOfWeek.AddDays(7);

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                acknowledgements = context.Acknowledgements.AsNoTracking().Include(a => a.Tags)
                    .Where(a => a.DateCreated >= startOfWeek && a.DateCreated < endOfWeek).OrderByDescending(a => a.DateCreated).ToList();
            }

            return assembler.AssembleCollection(acknowledgements);
        }

        public IEnumerable<AcknowledgementDTO> GetThisMonthAcknowledgements()
        {
            IEnumerable<Acknowledgement> acknowledgements;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                acknowledgements = context.Acknowledgements.AsNoTracking().Include(a => a.Tags)
                    .Where(a => a.DateCreated.Year == DateTime.Today.Year &&
                                a.DateCreated.Month == DateTime.Today.Month).OrderByDescending(a => a.DateCreated).ToList();
            }

            return assembler.AssembleCollection(acknowledgements);
        }

        public IEnumerable<AcknowledgementDTO> GetLastAcknowledgements()
        {
            IEnumerable<Acknowledgement> acknowledgements;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                acknowledgements = context.Acknowledgements.AsNoTracking().Include(a => a.Tags)
                    .OrderByDescending(a => a.DateCreated).Take(10).ToList();
            }

            return assembler.AssembleCollection(acknowledgements);
        }

        public string GetAllTimeChampion()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.Acknowledgements.GroupBy(a => a.BeneficiaryUsername,
                    (key, values) => new { Username = key, Count = values.Count() })
                    .OrderByDescending(b => b.Count).Select(b => b.Username).First();
            }
        }

        // TODO: Review return type
        public Dictionary<string, int> GetAllTimeTopTen()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.Acknowledgements.GroupBy(a => a.BeneficiaryUsername,
                    (key, values) => new { Username = key, Count = values.Count() })
                    .OrderByDescending(b => b.Count).Take(10).ToDictionary(b => b.Username, b => b.Count);
            }
        }

        public Dictionary<string, int> GetThisMonthTopTen()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.Acknowledgements
                    .Where(a => a.DateCreated.Month == DateTime.Today.Month && a.DateCreated.Year == DateTime.Today.Year)
                    .GroupBy(a => a.BeneficiaryUsername, (key, values) => new { Username = key, Count = values.Count() })
                    .OrderByDescending(b => b.Count).Take(10)
                    .ToDictionary(b => b.Username, b => b.Count);
            }
        }

        public void Add(AcknowledgementDTO acknowledgementDto)
        {
            var acknowledgement = assembler.Disassemble(acknowledgementDto);

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Acknowledgements.Add(acknowledgement);
                context.SaveChanges();
            }
        }

        public void Add(AcknowledgementDTO acknowledgementDto, IEnumerable<string> tags)
        {
            var acknowledgement = assembler.Disassemble(acknowledgementDto);
            acknowledgement.Tags = new List<Tag>();

            using (var context = new AcknowledgementsTrackerContext())
            {
                foreach (var tag in tags)
                {
                    // Verify if tag already exists
                    if (tagsRepo.Get(tag) != null)
                    {
                        // Add existing tag from database
                        context.Database.Log = message => Debug.WriteLine(message);
                        acknowledgement.Tags.Add(context.Tags.Where(t => t.Title == tag).FirstOrDefault());
                    }
                    else
                    {
                        // Create new tag and add it to tags
                        Tag newTag = new Tag();
                        newTag.Title = tag;

                        acknowledgement.Tags.Add(newTag);
                    }
                }

                context.Database.Log = message => Debug.WriteLine(message);
                context.Acknowledgements.Add(acknowledgement);
                context.SaveChanges();
            }
        }

        public void Edit(AcknowledgementDTO acknowledgementDto)
        {
            var acknowledgement = assembler.Disassemble(acknowledgementDto);

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Entry(acknowledgement).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Entry(context.Acknowledgements.Find(id)).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
