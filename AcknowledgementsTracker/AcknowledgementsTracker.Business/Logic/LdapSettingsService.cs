namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using Interfaces;

    public class LdapSettingsService : ILdapSettingsService
    {
        public string ServerPath { get; set; }

        public string SearchRoot { get; set; }

        public string Username { get; set; }

        public string UserPassword { get; set; }
    }
}
