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

    public class TagDTO
    {
        public TagDTO()
        {
            Acknowledgements = new HashSet<Acknowledgement>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Acknowledgement> Acknowledgements { get; set; }
    }
}
