namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using System.DirectoryServices.Protocols;
    using System.Linq;
    using System.Net;
    using Interfaces;

    public class LdapManager : ILdapManager
    {
        private LdapConnection connection;
        private LdapDirectoryIdentifier serverId;

        public LdapManager(string serverPath)
        {
            serverId = new LdapDirectoryIdentifier(serverPath);
            connection = new LdapConnection(serverId);
        }

        public bool ValidateUser(string username, string password)
        {
            var isValid = true;
            var userId = $"uid={username},ou=People,dc=proxiad,dc=bg";
            var credentials = new NetworkCredential(userId, password);

            using (var testConnection = new LdapConnection(serverId, credentials))
            {
                try
                {
                    testConnection.Bind();
                }
                catch (Exception)
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        public string GetUserFullname(string baseDn, string username)
        {
            string fullname = null;
            string ldapFilter = $"uid={username}";

            try
            {
                var request = new SearchRequest(baseDn, ldapFilter, SearchScope.OneLevel, null);
                var response = (SearchResponse)connection.SendRequest(request);

                fullname = response.Entries[0].DistinguishedName;
            }
            catch (Exception)
            {
                return null;
            }

            return fullname;
        }

        public string GetUserEmail(string baseDn, string username)
        {
            string email = null;
            string ldapFiletr = $"uid={username}";
            string[] attributesToReturn = { "mail" };

            try
            {
                var request = new SearchRequest(baseDn, ldapFiletr, SearchScope.OneLevel, attributesToReturn);
                var response = (SearchResponse)connection.SendRequest(request);

                var attributes = response.Entries[0].Attributes;

                foreach (DirectoryAttribute attribute in attributes.Values)
                {
                    email = (string)attribute[0];
                }
            }
            catch (Exception)
            {
                return null;
            }

            return email;
        }
    }
}
