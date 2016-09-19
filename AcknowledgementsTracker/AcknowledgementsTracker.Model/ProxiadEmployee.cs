//-----------------------------------------------------------------------
// <copyright file="ProxiadEmployee.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProxiadEmployee
    {
        public ProxiadEmployee()
        {
            AcknowledgementsReceived = new HashSet<Acknowledgement>();
            AcknowledgementsGiven = new HashSet<Acknowledgement>();
        }

        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        public ICollection<Acknowledgement> AcknowledgementsReceived { get; set; }

        public ICollection<Acknowledgement> AcknowledgementsGiven { get; set; }
    }
}
