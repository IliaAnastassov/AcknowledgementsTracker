//-----------------------------------------------------------------------
// <copyright file="Acknowledgement.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.Model.Models
{
    using System;
    using Contracts;

    public class Acknowledgement : IAcknowledgement
    {
        private string text;
        // FK to ProxiadEmployee
        private int proxiadEmployeeId;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public int ProxiadEmployeeId
        {
            get { return proxiadEmployeeId; }
            set { proxiadEmployeeId = value; }
        }

    }
}
