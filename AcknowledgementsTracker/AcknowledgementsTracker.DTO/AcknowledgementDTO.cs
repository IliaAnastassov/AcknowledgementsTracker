﻿//-----------------------------------------------------------------------
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

    public class AcknowledgementDTO
    {
        public AcknowledgementDTO()
        {
            Tags = new HashSet<Tag>();
            DateCreated = DateTime.Now;
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public ProxiadEmployee Author { get; set; }

        public int AuthorId { get; set; }

        public ProxiadEmployee Beneficiary { get; set; }

        public int BeneficiaryId { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}