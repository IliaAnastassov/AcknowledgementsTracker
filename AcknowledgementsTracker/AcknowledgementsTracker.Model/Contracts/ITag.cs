// <copyright file="ITag.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
using System.Collections.Generic;
using AcknowledgementsTracker.Model.Models;

namespace AcknowledgementsTracker.Model.Contracts
{
    public interface ITag
    {
        int Id { get; set; }

        string Title { get; set; }

        List<Acknowledgement> Acknowledgements { get; set; }
    }
}
