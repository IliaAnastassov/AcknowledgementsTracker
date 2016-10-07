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
    using Context;
    using DTO;
    using Interfaces;
    using Model;

    public class AcknowledgementsRepository : IRepository<AcknowledgementDTO>
    {
        private AcknowledgementDtoAssembler assembler = new AcknowledgementDtoAssembler();

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

        public IEnumerable<AcknowledgementDTO> GetAcknowledgements(string employeeEmail)
        {
            IEnumerable<Acknowledgement> acknowledgements;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                acknowledgements = context.Acknowledgements.AsNoTracking().Include(a => a.Tags)
                    .Where(a => a.BeneficiaryEmail == employeeEmail).ToList();
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
                                a.DateCreated.Day == DateTime.Today.Day).ToList();
            }

            return assembler.AssembleCollection(acknowledgements);
        }

        public IEnumerable<AcknowledgementDTO> GetThisWeekAcknowledgements()
        {
            IEnumerable<Acknowledgement> acknowledgements;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var lastWeek = DateTime.Today.AddDays(-7);
                acknowledgements = context.Acknowledgements.AsNoTracking().Include(a => a.Tags)
                    .Where(a => a.DateCreated >= lastWeek).ToList();
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
                                a.DateCreated.Month == DateTime.Today.Month).ToList();
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
                    .OrderBy(a => a.DateCreated).Take(10).ToList();
            }

            return assembler.AssembleCollection(acknowledgements);
        }

        public void Add(AcknowledgementDTO acknowledgementDto)
        {
            var acknowledgement = assembler.Disassemble((AcknowledgementDTO)acknowledgementDto);

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Acknowledgements.Add(acknowledgement);
                context.SaveChanges();
            }
        }

        public void Edit(AcknowledgementDTO acknowledgementDto)
        {
            var acknowledgement = assembler.Disassemble((AcknowledgementDTO)acknowledgementDto);

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
