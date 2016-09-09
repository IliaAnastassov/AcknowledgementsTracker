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
    using Contracts;

    public class ProxiadEmployee : IProxiadEmployee
    {
        private int id;
        private string userName;
        private string email;
        private List<Acknowledgement> acknowledgements;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public List<Acknowledgement> Acknowledgements
        {
            get { return acknowledgements; }
            set { acknowledgements = value; }
        }
    }
}
