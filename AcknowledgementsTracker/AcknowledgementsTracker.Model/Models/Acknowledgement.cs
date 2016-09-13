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
    using Contracts;

    public class Acknowledgement : IAcknowledgement
    {
        public Acknowledgement()
        {
            Tags = new List<Tag>();
            TagIds = new List<int>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(1500)]
        public string Text { get; set; }

        [Required]
        public ProxiadEmployee ProxiadEmployee { get; set; }

        public int ProxiadEmployeeId { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual List<Tag> Tags { get; set; }

        public virtual List<int> TagIds { get; set; }
    }
}
