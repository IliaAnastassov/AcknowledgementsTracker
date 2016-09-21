//-----------------------------------------------------------------------
// <copyright file="Acknowledgement.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Acknowledgement
    {
        public Acknowledgement()
        {
            Tags = new HashSet<Tag>();
            DateCreated = DateTime.Now;
        }

        public int AcknowledgementId { get; set; }

        [Required, MaxLength(1500)]
        public string Text { get; set; }

        public int AuthorId { get; set; }

        public int BeneficiaryId { get; set; }

        public DateTime DateCreated { get; set; }

        // Navigation properties
        public virtual Employee Author { get; set; }

        public virtual Employee Beneficiary { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
