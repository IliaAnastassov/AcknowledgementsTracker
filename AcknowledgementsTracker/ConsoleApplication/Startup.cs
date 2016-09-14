﻿// <copyright file="Startup.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace ConsoleApplication
{
    using System;
    using System.Data.Entity;
    using AcknowledgementsTracker.Business;
    using AcknowledgementsTracker.DataAccess;
    using AcknowledgementsTracker.DataAccess.Repositories;

    /// <summary>
    /// This is a testing application
    /// </summary>
    public class Startup
    {
        // TODO: Review multiple Include statements in Repositories

        /// <summary>
        /// Uncomment any bundle of code in order to test a repository method
        /// </summary>
        public static void Main()
        {
            Database.SetInitializer(new NullDatabaseInitializer<AcknowledgementsTrackerContext>());

            var acknowledgementsRepo = new AcknowledgementsRepository();
            var employeesRepo = new ProxiadEmployeesRepository();
            var tagsRepo = new TagsRepository();
            var printer = new Printer();

            // Wolverine's acknowledgements
            ////int employeeId = 5;
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

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
