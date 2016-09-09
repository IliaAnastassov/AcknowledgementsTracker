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
    using System.Collections.Generic;

    public class Acknowledgement : IAcknowledgement
    {
        private int id;
        private string text;
        private ProxiadEmployee proxiadEmployee;
        private int proxiadEmployeeId;
        private DateTime dateCreated;
        private List<Tag> tags;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public ProxiadEmployee ProxiadEmployee
        {
            get { return proxiadEmployee; }
            set { proxiadEmployee = value; }
        }

        public int ProxiadEmployeeId
        {
            get { return proxiadEmployeeId; }
            set { proxiadEmployeeId = value; }
        }

        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        public List<Tag> Tags
        {
            get { return tags; }
            set { tags = value; }
        }
    }
}
