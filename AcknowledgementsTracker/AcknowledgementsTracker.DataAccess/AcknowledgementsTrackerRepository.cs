namespace AcknowledgementsTracker.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model.Models;
    using System.Diagnostics;
    using System.Data.Entity;

    public class AcknowledgementsTrackerRepository
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

        public ProxiadEmployee GetProxiadEmployee(string name)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.ProxiadEmployees.Find(name);
            }
        }

        #region Dashboard
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
        #endregion

        public void SaveAcknowledgement(string text, int employeeId, List<int> tagIds)
        {
            var acknowledgement = new Acknowledgement()
            {
                Text = text,
                DateCreated = DateTime.Now,
                ProxiadEmployeeId = employeeId,
                TagIds = tagIds
            };

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Acknowledgements.Add(acknowledgement);
                context.SaveChanges();
            }
        }

        public void SaveProxiadEmployee(string userName, string email)
        {
            var employee = new ProxiadEmployee()
            {
                UserName = userName,
                Email = email
            };

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = Console.WriteLine;
                context.ProxiadEmployees.Add(employee);
                context.SaveChanges();
            }
        }

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

        public void DeleteAcknowledgement()
        {
            // TODO:
        }

        public void DeleteProxiadEmployee()
        {
            // TODO:
        }

        public void DeleteTag()
        {
            // TODO:
        }

        public void EditAcknowledgement()
        {
            // TODO:
        }

        public void EditProxiadEmployee()
        {
            // TODO:
        }

        public void EditTag()
        {
            // TODO:
        }
    }
}
