namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.DirectoryServices;
    using Interfaces;

    public class LdapConnection
    {
        public DirectoryEntry RootEntry { get; }

        public LdapConnection(ILdapSettingsService settings)
        {
            RootEntry = new DirectoryEntry(settings.Path, settings.Username, settings.UserPassword, AuthenticationTypes.None);
        }

        public bool IsAuthenticated()
        {
            if (RootEntry == null)
            {
                return false;
            }

            return true;
        }
    }
}
