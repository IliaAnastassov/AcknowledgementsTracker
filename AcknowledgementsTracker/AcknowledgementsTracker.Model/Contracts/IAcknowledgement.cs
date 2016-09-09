//-----------------------------------------------------------------------
// <copyright file="IAcknowledgement.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.Model.Contracts
{
    public interface IAcknowledgement
    {
        string Text { get; set; }
        int ProxiadEmployeeId { get; set; }
    }
}
