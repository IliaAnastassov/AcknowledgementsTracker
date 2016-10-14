// <copyright file="TagDTO.cs" company="Proxiad Bulgaria">
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

    public class TagDTO : IDto
    {
        public TagDTO()
        {
            Acknowledgements = new HashSet<AcknowledgementDTO>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<AcknowledgementDTO> Acknowledgements { get; set; }
    }
}
