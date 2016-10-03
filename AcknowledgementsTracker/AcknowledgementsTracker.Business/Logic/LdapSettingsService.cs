namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using Interfaces;

    public class LdapSettingsService : ILdapSettingsService
    {
        public string Path { get; set; }

        public string Username { get; set; }

        public string UserPassword { get; set; }
    }
}
