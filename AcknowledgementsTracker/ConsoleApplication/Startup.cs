// <copyright file="Startup.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace ConsoleApplication
{
    using System;
    using System.Data.Entity;
    using AcknowledgementsTracker.Business.Logic;
    using AcknowledgementsTracker.DataAccess.Context;
    using AcknowledgementsTracker.DataAccess.Repositories;

    /// <summary>
    /// This is a testing application
    /// </summary>
    public class Startup
    {
        // TODO: Move the Assembler in a separate project
        // TODO: Implement the Assembler in order to transform DTOs to Model objects and vice versa
        // TODO: Review multiple Include statements in Repositories
        // TODO: Test Save(), Edit() and Delete() methods in AcknowledgementsRepository
        // TODO: Test Save(), Edit() and Delete() methods in ProxiadEmployeesRepository
        // TODO: Test Save(), Edit() and Delete() methods in TagsRepository

        /// <summary>
        /// Uncomment any bundle of code in order to test the corresponding repository method
        /// </summary>
        public static void Main()
        {
            Database.SetInitializer(new NullDatabaseInitializer<AcknowledgementsTrackerContext>());

            var acknowledgementsRepo = new AcknowledgementsRepository();
            var employeesRepo = new ProxiadEmployeesRepository();
            var tagsRepo = new TagsRepository();
            var printer = new Printer();
            ////int employeeId = 5;

            // Wolverine's acknowledgements
            ////var acknowledgements = acknowledgementsRepo.GetAcknowledgements(employeeId);
            ////var employee = employeesRepo.GetProxiadEmployee(employeeId);
            ////Console.WriteLine($"{employee.UserName}'s acknowledgements:\n");
            ////printer.PrintAcknowledgements(acknowledgements);

            // Today's acknowledgements
            ////var todaysAcknowledgements = acknowledgementsRepo.GetTodaysAcknowledgements();
            ////Console.WriteLine("Today's acknowledgements:\n");
            ////printer.PrintAcknowledgements(todaysAcknowledgements);

            // This week's acknowledgements
            ////var thisWeekAcknowledgements = acknowledgementsRepo.GetThisWeekAcknowledgements();
            ////Console.WriteLine("This week's acknowledgements:\n");
            ////printer.PrintAcknowledgements(thisWeekAcknowledgements);

            // This month's acknowledgements
            ////var thisMonthAcknowledgements = acknowledgementsRepo.GetThisMonthAcknowledgements();
            ////Console.WriteLine("This month's acknowledgements:\n");
            ////printer.PrintAcknowledgements(thisWeekAcknowledgements);

            // Last acknowledgements
            ////var lastAcknowledgements = acknowledgementsRepo.GetLastAcknowledgements();
            ////Console.WriteLine("Last acknowledgements:\n");
            ////printer.PrintAcknowledgements(lastAcknowledgements);

            // Get Proxiad Employee
            ////var employeeById = employeesRepo.GetProxiadEmployee(employeeId);
            ////Console.WriteLine($"Employee with id {employeeId} is {employee.UserName}");

            // Get most acknowledged employee all time
            ////var bestEmployee = employeesRepo.GetMostAcknowledgedPersonAllTime();
            ////Console.WriteLine($"Most acknowledged employee all time: {bestEmployee.UserName}");

            // Get most acknowledged employee of the month
            ////var monthsEmployee = employeesRepo.GetMostAcknowledgedPersonOfMonth();
            ////Console.WriteLine($"Most acknowledged employee this month: {monthsEmployee.UserName}");

            // Get the existing tags
            ////var tags = tagsRepo.GetTags();
            ////Console.WriteLine("Existing tags:\n");
            ////tags.ForEach(t => Console.WriteLine(t.Title));

            // Get specific tag
            ////var tag = tagsRepo.GetTag(6);
            ////Console.WriteLine(tag.Title);

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
