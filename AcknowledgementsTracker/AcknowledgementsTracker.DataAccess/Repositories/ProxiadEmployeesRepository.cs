namespace AcknowledgementsTracker.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;
    using Model.Models;

    public class ProxiadEmployeesRepository
    {
        public ProxiadEmployee GetProxiadEmployee(string name)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = Console.WriteLine;
                return context.ProxiadEmployees.Find(name);
            }
        }

        public ProxiadEmployee GetMostAcknowledgedPersonAllTime()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.ProxiadEmployees.AsNoTracking().OrderByDescending(e => e.Acknowledgements.Count).FirstOrDefault();
            }
        }

        public ProxiadEmployee GetMostAcknowledgedPersonOfMonth()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.ProxiadEmployees.AsNoTracking()
                                               .OrderByDescending(
                                                    e => e.Acknowledgements
                                                    .Where(a => a.DateCreated.Year == DateTime.Now.Year && a.DateCreated.Month == DateTime.Now.Month)
                                                )
                                                .FirstOrDefault();
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

        public void EditProxiadEmployee()
        {
            // TODO:
        }

        public void DeleteProxiadEmployee()
        {
            // TODO:
        }
    }
}
