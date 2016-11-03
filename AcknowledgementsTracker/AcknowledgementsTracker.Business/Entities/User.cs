namespace AcknowledgementsTracker.Business.Entities
{
    using System;
    using Interfaces;

    public class User : IUser
    {
        public User(string name, string email, string team = null)
        {
            this.Name = name;
            this.Email = email;
            this.Team = team;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Team { get; set; }
    }
}
