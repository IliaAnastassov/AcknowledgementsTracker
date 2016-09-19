// <copyright file="AcknowledgementsTrackerContext.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.DataAccess.Context
{
    using System;
    using System.Data.Entity;
    using Model;

    public class AcknowledgementsTrackerContext : DbContext
    {
        public DbSet<Acknowledgement> Acknowledgements { get; set; }

        public DbSet<ProxiadEmployee> ProxiadEmployees { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProxiadEmployee>()
                .HasMany(p => p.AcknowledgementsGiven)
                .WithRequired(a => a.Author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProxiadEmployee>()
                .HasMany(p => p.AcknowledgementsReceived)
                .WithRequired(a => a.Beneficiary)
                .WillCascadeOnDelete(false);
        }
    }
}
