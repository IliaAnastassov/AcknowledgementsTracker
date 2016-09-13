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
    using System.ComponentModel.DataAnnotations.Schema;

    public class Acknowledgement
    {
        public Acknowledgement()
        {
            Tags = new List<Tag>();
            TagIds = new List<int>();
            DateCreated = DateTime.Now;
        }

        public int Id { get; set; }

        [MaxLength(1500)]
        public string Text { get; set; }

        [ForeignKey("AuthorId")]
        [Required]
        public virtual ProxiadEmployee Author { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("BeneficiaryId")]
        [Required]
        public ProxiadEmployee Beneficiary { get; set; }

        public int BeneficiaryId { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public List<Tag> Tags { get; set; }

        public List<int> TagIds { get; set; }
    }
}
