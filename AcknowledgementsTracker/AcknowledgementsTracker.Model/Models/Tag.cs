// <copyright file="Tag.cs" company="Proxiad Bulgaria">
//     Copyright (c) Proxiad Bulgaria. All rights reserved.
// </copyright>
// <author>Ilia Anastassov</author>
//-----------------------------------------------------------------------
namespace AcknowledgementsTracker.Model.Models
{
    using System.Collections.Generic;
    using Contracts;

    public class Tag : ITag
    {
        private int id;
        private string title;
        private List<Acknowledgement> acknowledgements;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public List<Acknowledgement> Acknowledgements
        {
            get { return acknowledgements; }
            set { acknowledgements = value; }
        }
    }
}
