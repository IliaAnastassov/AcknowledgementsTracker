//-----------------------------------------------------------------------
// <copyright file="ProxiadEmployee.cs" company="Proxiad Bulgaria">
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

    public class ProxiadEmployee : IProxiadEmployee
    {
        public ProxiadEmployee()
        {
            Acknowledgements = new List<Acknowledgement>();
            AcknowledgementIds = new List<int>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        public virtual List<Acknowledgement> Acknowledgements { get; set; }

        public virtual List<int> AcknowledgementIds { get; set; }
    }
}
