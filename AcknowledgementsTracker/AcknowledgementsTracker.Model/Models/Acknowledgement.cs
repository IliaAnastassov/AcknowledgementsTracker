//-----------------------------------------------------------------------
// <copyright file="Acknowledgement.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Acknowledgement
    {
        public Acknowledgement()
        {
            Tags = new List<Tag>();
            TagIds = new List<int>();
            DateCreated = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(1500)]
        public string Text { get; set; }

        [Required]
        public ProxiadEmployee Author { get; set; }

        public int AuthorId { get; set; }

        [Required]
        public ProxiadEmployee Beneficiary { get; set; }

        public ProxiadEmployee BeneficiaryId { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual List<Tag> Tags { get; set; }

        public virtual List<int> TagIds { get; set; }
    }
}
