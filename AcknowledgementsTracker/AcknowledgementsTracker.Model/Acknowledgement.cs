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

        public string NormalizedText { get; set; }

        public string AuthorUsername { get; set; }

        public string BeneficiaryUsername { get; set; }

        public DateTime DateCreated { get; set; }

        // Navigation properties
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
