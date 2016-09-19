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
    using Model;
    using Interfaces;
    using Context;

    public class AcknowledgementsRepository : IAcknowledgementsRepository
    {
        public List<Acknowledgement> GetAcknowledgements(int employeeId)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.Acknowledgements.AsNoTracking().Include(a => a.Tags).Include(a => a.Author).Where(a => a.BeneficiaryId == employeeId).ToList();
            }
        }

        public List<Acknowledgement> GetTodaysAcknowledgements()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.Acknowledgements.AsNoTracking().Include(a => a.Tags).Include(a => a.Author).Include(a => a.Beneficiary)
                    .Where(a => a.DateCreated.Year == DateTime.Today.Year &&
                                a.DateCreated.Month == DateTime.Today.Month &&
                                a.DateCreated.Day == DateTime.Today.Day).ToList();
            }
        }

        public List<Acknowledgement> GetThisWeekAcknowledgements()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                var lastWeek = DateTime.Today.AddDays(-7);
                return context.Acknowledgements.AsNoTracking().Include(a => a.Tags).Include(a => a.Author).Include(a => a.Beneficiary)
                    .Where(a => a.DateCreated >= lastWeek).ToList();
            }
        }

        public List<Acknowledgement> GetThisMonthAcknowledgements()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.Acknowledgements.AsNoTracking().Include(a => a.Tags).Include(a => a.Author).Include(a => a.Beneficiary)
                    .Where(a => a.DateCreated.Year == DateTime.Today.Year &&
                                a.DateCreated.Month == DateTime.Today.Month).ToList();
            }
        }

        public List<Acknowledgement> GetLastAcknowledgements()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.Acknowledgements.AsNoTracking().Include(a => a.Tags).Include(a => a.Author).Include(a => a.Beneficiary)
                    .OrderBy(a => a.DateCreated).Take(10).ToList();
            }
        }

        public void SaveAcknowledgement(Acknowledgement acknowledgement)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Acknowledgements.Add(acknowledgement);
                context.SaveChanges();
            }
        }

        public void EditAcknowledgement(Acknowledgement acknowledgement)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Entry(acknowledgement).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteAcknowledgement(int id)
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
