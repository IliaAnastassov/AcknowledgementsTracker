namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Net;
    using System.DirectoryServices.Protocols;
    using Interfaces;
    using System.Collections.Generic;

    public class LdapManager : ILdapManager
    {
        private LdapConnection connection;

        public LdapManager(string username, string passsword, string domain, string url)
        {
            var credentials = new NetworkCredential(username, passsword);
            var serverId = new LdapDirectoryIdentifier(url);

            connection = new LdapConnection(serverId, credentials);
        }

        public bool ValidateUser(string username, string password)
        {
            bool isValid = true;
            var credentials = new NetworkCredential(username, password);
            var serverId = new LdapDirectoryIdentifier(connection.SessionOptions.HostName);

            using (var bindConnection = new LdapConnection(serverId, credentials))
            {
                try
                {
                    bindConnection.Bind();
                }
                catch (Exception)
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        public List<Dictionary<string, string>> FindUser(string baseDn, string ldapFilter)
        {
            var result = new List<Dictionary<string, string>>();

            var request = new SearchRequest(baseDn, ldapFilter, SearchScope.Subtree, null);
            var response = (SearchResponse)connection.SendRequest(request);

            foreach (SearchResultEntry entry in response.Entries)
            {
                var dictionary = new Dictionary<string, string>();
                dictionary["DN"] = entry.DistinguishedName;

                foreach (string attributeName in entry.Attributes.AttributeNames)
                {
                    dictionary[attributeName] = string.Join(",", entry.Attributes[attributeName].GetValues(typeof(string)));
                }

                result.Add(dictionary);
            }

            return result;
        }
    }
}
