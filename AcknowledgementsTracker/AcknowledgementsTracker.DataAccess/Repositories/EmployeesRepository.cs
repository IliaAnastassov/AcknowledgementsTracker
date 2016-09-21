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

    public class EmployeesRepository : IRepository<IDto>
    {
        private EmployeeDtoAssembler assembler = new EmployeeDtoAssembler();

        public IDto Get(int id)
        {
            Employee employee;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                employee = context.Employees.Find(id);
            }

            return assembler.Assemble(employee);
        }

        public IEnumerable<IDto> GetAll()
        {
            IEnumerable<Employee> employees;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                employees = context.Employees.ToList();
            }

            return assembler.AssembleCollection(employees);
        }

        public IDto GetMostAcknowledgedPersonAllTime()
        {
            Employee employee;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                employee = context.Employees.AsNoTracking().OrderByDescending(e => e.AcknowledgementsReceived.Count).FirstOrDefault();
            }

            return assembler.Assemble(employee);
        }

        public IDto GetMostAcknowledgedPersonOfMonth()
        {
            Employee employee;

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = message => Debug.WriteLine(message);
                employee = context.Employees.AsNoTracking()
                    .OrderByDescending(e => e.AcknowledgementsReceived
                    .Where(a => a.DateCreated.Year == DateTime.Now.Year && a.DateCreated.Month == DateTime.Now.Month).Count())
                    .FirstOrDefault();
            }

            return assembler.Assemble(employee);
        }

        public void Add(IDto employeeDto)
        {
            var employee = assembler.Disassemble((EmployeeDTO)employeeDto);

            using (var context = new AcknowledgementsTrackerContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public void Edit(IDto employeeDto)
        {
            var employee = assembler.Disassemble((EmployeeDTO)employeeDto);

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
                context.Entry(context.Employees.Find(id)).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
