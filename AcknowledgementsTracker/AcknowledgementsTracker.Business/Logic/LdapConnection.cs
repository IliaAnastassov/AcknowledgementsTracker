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
            var userId = $"uid={settings.Username},ou=People,dc=proxiad,dc=bg";
            RootEntry = new DirectoryEntry(settings.Path, userId, settings.UserPassword, AuthenticationTypes.None);
        }

        public bool IsAuthenticated()
        {
            if (RootEntry.SchemaEntry == null)
            {
                return false;
            }

            return true;
        }
    }
}
