﻿// <copyright file="AcknowledgementsTrackerContext.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.DataAccess
{
    using System;
    using System.Data.Entity;
    using Model.Models;

    public class AcknowledgementsTrackerContext : DbContext
    {
        public DbSet<Acknowledgement> Acknowledgements { get; set; }

        public DbSet<ProxiadEmployee> ProxiadEmployees { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}