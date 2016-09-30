namespace AcknowledgementsTracker.Presentation.LDAP
{
    using System;
    using System.DirectoryServices;

    public class LdapConnection
    {
        public DirectoryEntry RootEntry { get; }

        public LdapConnection()
        {
            string path = Properties.Settings.Default.LDAPServerPath;
            string username = Properties.Settings.Default.LDAPUsername;
            string userPassword = Properties.Settings.Default.LDAPUserPassword;
            RootEntry = new DirectoryEntry(path, username, userPassword, AuthenticationTypes.None);
        }
    }
}
