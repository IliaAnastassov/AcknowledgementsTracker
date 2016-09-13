// <copyright file="ITag.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.Model.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface ITag
    {
        int Id { get; set; }

        string Title { get; set; }

        List<Acknowledgement> Acknowledgements { get; set; }

        List<int> AcknowledgementIds { get; set; }
    }
}
