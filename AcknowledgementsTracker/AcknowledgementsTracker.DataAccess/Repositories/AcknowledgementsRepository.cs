namespace AcknowledgementsTracker.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;
    using Model.Models;

    public class AcknowledgementsRepository
    {
        public List<Acknowledgement> GetAcknowledgements(int proxiadEmployeeId)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                ////context.Database.Log = message => Debug.WriteLine(message);
                context.Database.Log = Console.WriteLine;

                return context.Acknowledgements.AsNoTracking().Include(a => a.Tags).Where(a => a.ProxiadEmployeeId == proxiadEmployeeId).ToList();
            }
        }

        public List<Acknowledgement> GetTodaysAcknowledgements()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.Acknowledgements.AsNoTracking().Where(a => a.DateCreated == DateTime.Today).ToList();
            }
        }

        public List<Acknowledgement> GetThisWeekAcknowledgements()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.Acknowledgements.AsNoTracking().Where(a => a.DateCreated >= DateTime.Now.AddDays(-7)).ToList();
            }
        }

        public List<Acknowledgement> GetThisMonthAcknowledgements()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.Acknowledgements.AsNoTracking().Where(a => a.DateCreated.Month == DateTime.Now.Month).ToList();
            }
        }

        public List<Acknowledgement> GetLastAcknowledgements()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.Acknowledgements.AsNoTracking().OrderBy(a => a.DateCreated).Take(10).ToList();
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
