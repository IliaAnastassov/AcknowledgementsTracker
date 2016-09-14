// <copyright file="ProxiadEmployeesRepository.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.DataAccess.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;
    using Model.Models;

    public class ProxiadEmployeesRepository
    {
        public ProxiadEmployee GetProxiadEmployee(int id)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.ProxiadEmployees.Find(id);
            }
        }

        public ProxiadEmployee GetMostAcknowledgedPersonAllTime()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.ProxiadEmployees.AsNoTracking().OrderByDescending(e => e.AcknowledgementsReceived.Count).FirstOrDefault();
            }
        }

        public ProxiadEmployee GetMostAcknowledgedPersonOfMonth()
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                return context.ProxiadEmployees.AsNoTracking().OrderByDescending(e => e.AcknowledgementsReceived.Where(a => a.DateCreated.Year == DateTime.Now.Year && a.DateCreated.Month == DateTime.Now.Month)).FirstOrDefault();
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

        public void EditProxiadEmployee(ProxiadEmployee employee)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProxiadEmployee(int id)
        {
            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Entry(context.ProxiadEmployees.Find(id)).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
