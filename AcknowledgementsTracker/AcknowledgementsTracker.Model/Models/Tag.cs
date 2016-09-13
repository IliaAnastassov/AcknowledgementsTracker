// <copyright file="Tag.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.Model.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        public Tag()
        {
            Acknowledgements = new List<Acknowledgement>();
            AcknowledgementIds = new List<int>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        public virtual List<Acknowledgement> Acknowledgements { get; set; }

        public virtual List<int> AcknowledgementIds { get; set; }
    }
}
