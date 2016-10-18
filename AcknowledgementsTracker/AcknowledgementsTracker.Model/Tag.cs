// <copyright file="Tag.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        public Tag()
        {
            Acknowledgements = new HashSet<Acknowledgement>();
        }

        public int TagId { get; set; }

        [Required, MaxLength(100)]
        [Index(IsUnique=true)]
        public string Title { get; set; }

        // Navigation Properties
        public virtual ICollection<Acknowledgement> Acknowledgements { get; set; }
    }
}
