namespace AcknowledgementsTracker.Model.Models
{
    using System;
    using Contracts;

    public class Tag : ITag
    {
        private int id;
        private string title;

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
    }
}
