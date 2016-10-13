namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.DirectoryServices;
    using Interfaces;

    public class LdapServerConnection : ILdapServerConnection
    {
        public string Username { get; set; }

        public DirectoryEntry RootEntry { get; }

        public LdapServerConnection(ILdapSettingsService settings)
        {
            Username = settings.Username;
            var ldapUsername = $"uid={Username},ou=People,dc=proxiad,dc=bg";
            RootEntry = new DirectoryEntry(settings.Path, ldapUsername, settings.UserPassword, AuthenticationTypes.None);
        }

        public bool IsAuthenticated()
        {
            try
            {
                var schema = RootEntry.SchemaEntry;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
