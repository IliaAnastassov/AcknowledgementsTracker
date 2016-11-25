namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.DirectoryServices;
    using System.Web;
    using Interfaces;

    public class LdapServerConnection : ILdapServerConnection
    {
        private const string UniqueIdProperty = "uid";
        private const string CommonNameProperty = "cn";
        private ILdapSettingsService settings;

        public LdapServerConnection(ILdapSettingsService settings)
        {
            this.settings = settings;
        }

        public string Username { get; private set; }

        public DirectoryEntry SearchRoot { get; private set; }

        public DirectoryEntry RootEntry { get; private set; }

        public bool IsAuthenticated { get; private set; }

        public void Connect()
        {
            IsAuthenticated = VerifyConnection(settings, UniqueIdProperty);

            if (!IsAuthenticated)
            {
                IsAuthenticated = VerifyConnection(settings, CommonNameProperty);
            }
        }

        private bool VerifyConnection(ILdapSettingsService settings, string identificationProperty)
        {
            Username = $"{identificationProperty}={settings.Username},ou=People,dc=proxiad,dc=bg";
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
