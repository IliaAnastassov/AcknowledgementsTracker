// <copyright file="ProxiadEmployeesRepository.cs" company="Proxiad Bulgaria">
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

    public class ProxiadEmployeesRepository : IRepository<IDto>
    {
        private ProxiadEmployeeDtoAssembler assembler = new ProxiadEmployeeDtoAssembler();

        public IDto Get(int id)
        {
            ProxiadEmployee employee;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                employee = context.ProxiadEmployees.Find(id);
            }

            return assembler.Assemble(employee);
        }

        public IEnumerable<IDto> GetAll()
        {
            IEnumerable<ProxiadEmployee> employees;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                employees = context.ProxiadEmployees.ToList();
            }

            return assembler.AssembleCollection(employees);
        }

        public IDto GetMostAcknowledgedPersonAllTime()
        {
            ProxiadEmployee employee;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                employee = context.ProxiadEmployees.AsNoTracking().OrderByDescending(e => e.AcknowledgementsReceived.Count).FirstOrDefault();
            }

            return assembler.Assemble(employee);
        }

        public IDto GetMostAcknowledgedPersonOfMonth()
        {
            ProxiadEmployee employee;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                employee = context.ProxiadEmployees.AsNoTracking()
                    .OrderByDescending(e => e.AcknowledgementsReceived
                    .Where(a => a.DateCreated.Year == DateTime.Now.Year && a.DateCreated.Month == DateTime.Now.Month).Count())
                    .FirstOrDefault();
            }

            return assembler.Assemble(employee);
        }

        public void Add(IDto employeeDto)
        {
            var employee = assembler.Disassemble((ProxiadEmployeeDTO)employeeDto);

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = Console.WriteLine;
                context.ProxiadEmployees.Add(employee);
                context.SaveChanges();
            }
        }

        public void Edit(IDto employeeDto)
        {
            var employee = assembler.Disassemble((ProxiadEmployeeDTO)employeeDto);

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Remove(int id)
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
