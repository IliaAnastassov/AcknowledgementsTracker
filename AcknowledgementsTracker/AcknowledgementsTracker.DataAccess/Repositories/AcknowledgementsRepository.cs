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
        private IAssembler<Acknowledgement, AcknowledgementDTO> acknowledgementsAssembler = new AcknowledgementDtoAssembler();
        private TagsRepository tagsRepo = new TagsRepository();

        public AcknowledgementDTO Get(int id)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var acknowledgement = context.Acknowledgements.Find(id);

                return acknowledgementsAssembler.Assemble(acknowledgement);
            }
        }

        public IEnumerable<AcknowledgementDTO> GetAll()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var acknowledgements = context.Acknowledgements.ToList();

                return acknowledgementsAssembler.AssembleCollection(acknowledgements)
                                                .ToList();
            }
        }

        public IEnumerable<AcknowledgementDTO> GetReceived(string username)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var acknowledgements = context.Acknowledgements
                                              .Include(a => a.Tags)
                                              .Where(a => a.BeneficiaryUsername == username)
                                              .OrderByDescending(a => a.DateCreated)
                                              .ToList();

                return acknowledgementsAssembler.AssembleCollection(acknowledgements)
                                                .ToList();
            }
        }

        public IEnumerable<AcknowledgementDTO> GetGiven(string username)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var acknowledgements = context.Acknowledgements
                                              .Include(a => a.Tags)
                                              .Where(a => a.AuthorUsername == username)
                                              .OrderByDescending(a => a.DateCreated)
                                              .ToList();

                return acknowledgementsAssembler.AssembleCollection(acknowledgements)
                                                .ToList();
            }
        }

        public IEnumerable<AcknowledgementDTO> GetTodaysAcknowledgements()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var acknowledgements = context.Acknowledgements
                                              .Include(a => a.Tags)
                                              .Where(a => a.DateCreated.Year == DateTime.Today.Year
                                                       && a.DateCreated.Month == DateTime.Today.Month
                                                       && a.DateCreated.Day == DateTime.Today.Day)
                                              .OrderByDescending(a => a.DateCreated)
                                              .ToList();

                return acknowledgementsAssembler.AssembleCollection(acknowledgements)
                                                .ToList();
            }
        }

        public IEnumerable<AcknowledgementDTO> GetThisWeekAcknowledgements()
        {
            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1),
                     endOfWeek = startOfWeek.AddDays(7);

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var acknowledgements = context.Acknowledgements
                                              .Include(a => a.Tags)
                                              .Where(a => a.DateCreated >= startOfWeek && a.DateCreated < endOfWeek)
                                              .OrderByDescending(a => a.DateCreated)
                                              .ToList();

                return acknowledgementsAssembler.AssembleCollection(acknowledgements)
                                                .ToList();
            }
        }

        public IEnumerable<AcknowledgementDTO> GetThisMonthAcknowledgements()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var acknowledgements = context.Acknowledgements
                                              .Include(a => a.Tags)
                                              .Where(a => a.DateCreated.Year == DateTime.Today.Year
                                                       && a.DateCreated.Month == DateTime.Today.Month)
                                              .OrderByDescending(a => a.DateCreated)
                                              .ToList();

                return acknowledgementsAssembler.AssembleCollection(acknowledgements)
                                                .ToList();
            }
        }

        public IEnumerable<AcknowledgementDTO> GetLastAcknowledgements()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var acknowledgements = context.Acknowledgements
                                              .Include(a => a.Tags)
                                              .OrderByDescending(a => a.DateCreated)
                                              .Take(10)
                                              .ToList();

                return acknowledgementsAssembler.AssembleCollection(acknowledgements)
                                                .ToList();
            }
        }

        public string GetAllTimeChampion()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var champion = context.Acknowledgements
                                      .GroupBy(
                                               a => a.BeneficiaryUsername,
                                               (key, values) => new { Username = key, Count = values.Count() })
                                      .OrderByDescending(b => b.Count)
                                      .Select(b => b.Username)
                                      .First();

                return champion;
            }
        }

        public Dictionary<string, int> GetAllTimeTopTen()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var topTenAllTime = context.Acknowledgements
                                           .GroupBy(
                                                    a => a.BeneficiaryUsername,
                                                    (key, values) => new { Username = key, Count = values.Count() })
                                           .OrderByDescending(b => b.Count)
                                           .Take(10)
                                           .ToDictionary(b => b.Username, b => b.Count);

                return topTenAllTime;
            }
        }

        public Dictionary<string, int> GetThisMonthTopTen()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var topTenThisMonth = context.Acknowledgements
                                             .Where(a => a.DateCreated.Month == DateTime.Today.Month
                                                      && a.DateCreated.Year == DateTime.Today.Year)
                                             .GroupBy(
                                                      a => a.BeneficiaryUsername,
                                                      (key, values) => new { Username = key, Count = values.Count() })
                                             .OrderByDescending(b => b.Count)
                                             .Take(10)
                                             .ToDictionary(b => b.Username, b => b.Count);

                return topTenThisMonth;
            }
        }

        public IEnumerable<AcknowledgementDTO> GetThisMonthsByUser(string username)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var acknowledgements = context.Acknowledgements
                                              .Where(a => a.BeneficiaryUsername == username
                                                       && a.DateCreated.Month == DateTime.Today.Month
                                                       && a.DateCreated.Year == DateTime.Today.Year)
                                              .OrderByDescending(a => a.DateCreated)
                                              .ToList();

                return acknowledgementsAssembler.AssembleCollection(acknowledgements)
                                                .ToList();
            }
        }

        public Dictionary<string, int> GetTopTenUsersByTag(string tagTitle)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                Tag tag = context.Tags.Where(t => t.Title == tagTitle).FirstOrDefault();

                var topTenByTag = context.Acknowledgements
                                         .Where(a => a.Tags.Contains(tag))
                                         .GroupBy(
                                                  a => a.BeneficiaryUsername,
                                                  (key, values) => new { Username = key, Count = values.Count() })
                                         .OrderByDescending(b => b.Count)
                                         .Take(10)
                                         .ToDictionary(b => b.Username, b => b.Count);

                return topTenByTag;
            }
        }

        public IEnumerable<AcknowledgementDTO> GetByTag(string tagTitle)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var tag = context.Tags
                                 .Where(t => t.Title == tagTitle)
                                 .FirstOrDefault();

                return acknowledgementsAssembler.AssembleCollection(tag.Acknowledgements)
                                                .ToList();
            }
        }

        public IEnumerable<AcknowledgementDTO> GetByTagThisMonth(string tagTitle)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var tag = context.Tags
                                 .Where(t => t.Title == tagTitle)
                                 .FirstOrDefault();

                var acknowledgements = tag.Acknowledgements
                                          .Where(a => a.DateCreated.Month == DateTime.Today.Month
                                                   && a.DateCreated.Year == DateTime.Today.Year)
                                          .OrderByDescending(a => a.DateCreated)
                                          .ToList();

                return acknowledgementsAssembler.AssembleCollection(acknowledgements)
                                                .ToList();
            }
        }

        public IEnumerable<AcknowledgementDTO> GetByUsername(string username)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var acknowledgements = context.Acknowledgements
                                              .Where(a => a.BeneficiaryUsername == username
                                                       || a.AuthorUsername == username)
                                              .ToList();

                return acknowledgementsAssembler.AssembleCollection(acknowledgements)
                                                .ToList();
            }
        }

        public IEnumerable<AcknowledgementDTO> GetByContent(string keyword)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);

                var acknowledgements = context.Acknowledgements
                                              .Where(a => a.NormalizedText.Contains(keyword))
                                              .ToList();

                return acknowledgementsAssembler.AssembleCollection(acknowledgements)
                                                .ToList();
            }
        }

        public void Add(AcknowledgementDTO acknowledgementDto)
        {
            var acknowledgement = acknowledgementsAssembler.Disassemble(acknowledgementDto);

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Acknowledgements.Add(acknowledgement);
                context.SaveChanges();
            }
        }

        public void Add(AcknowledgementDTO acknowledgementDto, IEnumerable<string> tags)
        {
            var acknowledgement = acknowledgementsAssembler.Disassemble(acknowledgementDto);
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
                        acknowledgement.Tags.Add(context.Tags
                                                        .Where(t => t.Title == tag)
                                                        .FirstOrDefault());
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
            var acknowledgement = acknowledgementsAssembler.Disassemble(acknowledgementDto);

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

        private List<Acknowledgement> GetByTagsOrContent(string search, AcknowledgementsTrackerContext context)
        {
            var acknowledgements = context.Acknowledgements.Where(a => a.NormalizedText.Contains(search)
                                                                    || a.Tags.Select(t => t.Title).Contains(search))
                                                           .OrderByDescending(a => a.DateCreated)
                                                           .ToList();

            return acknowledgements;
        }

        private List<Acknowledgement> GetByUsername(IEnumerable<string> usernames, string search, AcknowledgementsTrackerContext context)
        {
            List<Acknowledgement> acknowledgements = new List<Acknowledgement>();

            foreach (var username in usernames)
            {
                acknowledgements.AddRange(context.Acknowledgements
                                                 .Where(a => a.AuthorUsername == username
                                                          || a.BeneficiaryUsername == username
                                                          || a.Tags.Select(t => t.Title).Contains(search))
                                                 .OrderByDescending(a => a.DateCreated)
                                                 .ToList());
            }

            return acknowledgements;
        }
    }
}
