//-----------------------------------------------------------------------
// <copyright file="IAcknowledgement.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.Model.Contracts
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface IAcknowledgement
    {
        int Id { get; set; }

        string Text { get; set; }

        DateTime DateCreated { get; set; }

        int ProxiadEmployeeId { get; set; }

        List<Tag> Tags { get; set; }
    }
}
