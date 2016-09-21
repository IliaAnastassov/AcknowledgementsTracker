//-----------------------------------------------------------------------
// <copyright file="ProxiadEmployeeDTO.cs" company="Proxiad Bulgaria">
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

    public class EmployeeDTO : IDto
    {
        public EmployeeDTO()
        {
            AcknowledgementsReceived = new HashSet<Acknowledgement>();
            AcknowledgementsGiven = new HashSet<Acknowledgement>();
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Acknowledgement> AcknowledgementsReceived { get; set; }

        public virtual ICollection<Acknowledgement> AcknowledgementsGiven { get; set; }
    }
}
