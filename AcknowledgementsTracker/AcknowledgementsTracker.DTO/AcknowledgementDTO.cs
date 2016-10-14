//-----------------------------------------------------------------------
// <copyright file="AcknowledgementDTO.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.DTO
{
    using System;
    using System.Collections.Generic;
    using Model;
    using Interfaces;

    public class AcknowledgementDTO : IDto
    {
        public AcknowledgementDTO()
        {
            Tags = new HashSet<TagDTO>();
            DateCreated = DateTime.Now;
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public string AuthorUsername { get; set; }

        public string BeneficiaryUsername { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<TagDTO> Tags { get; set; }
    }
}
