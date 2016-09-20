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
    using DTO.Interfaces;
    using Interfaces;
    using Model;

    public class AcknowledgementsRepository : IRepository<IDto>
    {
        private AcknowledgementDtoAssembler assembler = new AcknowledgementDtoAssembler();

        public IDto Get(int id)
        {
            Acknowledgement acknowledgement;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                acknowledgement = context.Acknowledgements.Find(id);
            }

            return assembler.Assemble(acknowledgement);
        }

        public IEnumerable<IDto> GetAll()
        {
            IEnumerable<Acknowledgement> acknowledgements;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                acknowledgements = context.Acknowledgements.ToList();
            }

            return assembler.AssembleCollection(acknowledgements);
        }

        public IEnumerable<IDto> GetAcknowledgements(int employeeId)
        {
            IEnumerable<Acknowledgement> acknowledgements;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                acknowledgements = context.Acknowledgements.AsNoTracking().Include(a => a.Tags).Include(a => a.Author).Where(a => a.BeneficiaryId == employeeId).ToList();
            }

            return assembler.AssembleCollection(acknowledgements);
        }

        public IEnumerable<IDto> GetTodaysAcknowledgements()
        {
            IEnumerable<Acknowledgement> acknowledgements;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                acknowledgements = context.Acknowledgements.AsNoTracking().Include(a => a.Tags).Include(a => a.Author).Include(a => a.Beneficiary)
                    .Where(a => a.DateCreated.Year == DateTime.Today.Year &&
                                a.DateCreated.Month == DateTime.Today.Month &&
                                a.DateCreated.Day == DateTime.Today.Day).ToList();
            }

            return assembler.AssembleCollection(acknowledgements);
        }

        public IEnumerable<IDto> GetThisWeekAcknowledgements()
        {
            IEnumerable<Acknowledgement> acknowledgements;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var lastWeek = DateTime.Today.AddDays(-7);
                acknowledgements = context.Acknowledgements.AsNoTracking().Include(a => a.Tags).Include(a => a.Author).Include(a => a.Beneficiary)
                    .Where(a => a.DateCreated >= lastWeek).ToList();
            }

            return assembler.AssembleCollection(acknowledgements);
        }

        public IEnumerable<IDto> GetThisMonthAcknowledgements()
        {
            IEnumerable<Acknowledgement> acknowledgements;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                acknowledgements = context.Acknowledgements.AsNoTracking().Include(a => a.Tags).Include(a => a.Author).Include(a => a.Beneficiary)
                    .Where(a => a.DateCreated.Year == DateTime.Today.Year &&
                                a.DateCreated.Month == DateTime.Today.Month).ToList();
            }

            return assembler.AssembleCollection(acknowledgements);
        }

        public IEnumerable<IDto> GetLastAcknowledgements()
        {
            IEnumerable<Acknowledgement> acknowledgements;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                acknowledgements = context.Acknowledgements.AsNoTracking().Include(a => a.Tags).Include(a => a.Author).Include(a => a.Beneficiary)
                    .OrderBy(a => a.DateCreated).Take(10).ToList();
            }

            return assembler.AssembleCollection(acknowledgements);
        }

        public void Save(IDto acknowledgementDto)
        {
            var acknowledgement = assembler.Disassemble((AcknowledgementDTO)acknowledgementDto);

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Acknowledgements.Add(acknowledgement);
                context.SaveChanges();
            }
        }

        public void Edit(IDto acknowledgementDto)
        {
            var acknowledgement = assembler.Disassemble((AcknowledgementDTO)acknowledgementDto);

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Entry(acknowledgement).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
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
