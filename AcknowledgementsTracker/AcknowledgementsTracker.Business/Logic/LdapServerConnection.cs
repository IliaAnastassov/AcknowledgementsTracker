namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.DirectoryServices;
    using System.Web;
    using Interfaces;

    public class LdapServerConnection : ILdapServerConnection
    {
        private const string UIDProperty = "uid";
        private const string CNProperty = "cn";

        public string Username { get; private set; }

        public DirectoryEntry SearchRoot { get; private set; }

        public DirectoryEntry RootEntry { get; private set; }

        public bool IsAuthenticated { get; private set; }

        public bool IsUIDPropertyUsed { get; private set; }

        public void Connect(ILdapSettingsService settings)
        {
            IsAuthenticated = VerifyConnection(settings, UIDProperty);

            if (IsAuthenticated)
            {
                IsUIDPropertyUsed = true;
            }
            else
            {
                IsAuthenticated = VerifyConnection(settings, CNProperty);
            }
        }

        private bool VerifyConnection(ILdapSettingsService settings, string identificationProperty)
        {
            Username = $"{identificationProperty}={settings.Username},ou=People,dc=proxiad,dc=bg";
            RootEntry = new DirectoryEntry(settings.ServerPath, Username, settings.Password, AuthenticationTypes.None);
            SearchRoot = new DirectoryEntry(settings.SearchRoot, Username, settings.Password, AuthenticationTypes.None);

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
