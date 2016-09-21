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

    public class Employee
    {
        public Employee()
        {
            AcknowledgementsReceived = new HashSet<Acknowledgement>();
            AcknowledgementsGiven = new HashSet<Acknowledgement>();
        }

        public int EmployeeId { get; set; }

        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        // Navigation Properties
        public virtual ICollection<Acknowledgement> AcknowledgementsReceived { get; set; }

        public virtual ICollection<Acknowledgement> AcknowledgementsGiven { get; set; }
    }
}
