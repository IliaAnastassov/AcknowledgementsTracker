namespace AcknowledgementsTracker.Business.Entities
{
    using System;
    using Interfaces;

    public class User : IUser
    {
        public string Email { get; set; }

        public string Name { get; set; }
    }
}
