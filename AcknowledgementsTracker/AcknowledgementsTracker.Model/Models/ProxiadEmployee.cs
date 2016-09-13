//-----------------------------------------------------------------------
// <copyright file="ProxiadEmployee.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.Model.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProxiadEmployee
    {
        public ProxiadEmployee()
        {
            AcknowledgementsReceived = new List<Acknowledgement>();
            AcknowledgementsReceivedIds = new List<int>();
            AcknowledgementsGiven = new List<Acknowledgement>();
            AcknowledgementsGivenIds = new List<int>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }


        public List<Acknowledgement> AcknowledgementsReceived { get; set; }

        public List<int> AcknowledgementsReceivedIds { get; set; }

        public List<Acknowledgement> AcknowledgementsGiven { get; set; }

        public List<int> AcknowledgementsGivenIds { get; set; }
    }
}
