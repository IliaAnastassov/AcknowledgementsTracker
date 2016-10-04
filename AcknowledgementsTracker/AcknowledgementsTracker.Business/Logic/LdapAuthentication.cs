namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.DirectoryServices;

    public class LdapAuthentication
    {
        private LdapConnection connection;

        public LdapAuthentication(LdapConnection connection)
        {
            this.connection = connection;
        }

        public bool IsAuthenticated(string username, string password)
        {
            DirectorySearcher searcher = new DirectorySearcher(this.connection.RootEntry);
            searcher.Filter = $"(&(uid={username})(userPassword={password}))";
            searcher.PropertiesToLoad.Add("cn");
            SearchResult result = searcher.FindOne();

            if (result == null)
            {
                return false;
            }

            return true;
        }
    }
}
