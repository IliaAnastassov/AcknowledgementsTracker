namespace AcknowledgementsTracker.DTO
{
    using System;
    using System.Collections.Generic;
    using Model;

    public class TagDTO
    {
        public TagDTO()
        {
            Acknowledgements = new HashSet<Acknowledgement>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Acknowledgement> Acknowledgements { get; set; }
    }
}
