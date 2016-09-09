﻿//-----------------------------------------------------------------------
// <copyright file="IProxiadEmployee.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.Model.Contracts
{
    using System.Collections.Generic;
    using AcknowledgementsTracker.Model.Models;

    public interface IProxiadEmployee
    {
        string UserName { get; set; }
        string Email { get; set; }
        List<Acknowledgement> Acknowledgements { get; set; }
    }
}
