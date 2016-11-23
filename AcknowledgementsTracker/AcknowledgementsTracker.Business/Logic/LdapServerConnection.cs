namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.DirectoryServices;
    using Interfaces;

    public class LdapServerConnection : ILdapServerConnection
    {
        public LdapServerConnection(ILdapSettingsService settings)
        {
            IsAuthenticated = VerifyConnection(settings, "uid");

            if (!IsAuthenticated)
            {
                IsAuthenticated = VerifyConnection(settings, "cn");
            }
        }

        public string Username { get; private set; }

        public DirectoryEntry SearchRoot { get; private set; }

        public DirectoryEntry RootEntry { get; private set; }

        public bool IsAuthenticated { get; private set; }

        private bool VerifyConnection(ILdapSettingsService settings, string prefix)
        {
            Username = $"{prefix}={settings.Username},ou=People,dc=proxiad,dc=bg";
            RootEntry = new DirectoryEntry(settings.ServerPath, Username, settings.UserPassword, AuthenticationTypes.None);
            SearchRoot = new DirectoryEntry(settings.SearchRoot, Username, settings.UserPassword, AuthenticationTypes.None);

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
