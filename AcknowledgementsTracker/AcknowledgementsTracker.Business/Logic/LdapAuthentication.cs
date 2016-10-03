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
            try
            {
                DirectorySearcher searcher = new DirectorySearcher(this.connection.RootEntry);
                searcher.Filter = $"&(uid={username})(userPassword={password})";
                searcher.PropertiesToLoad.Add("cn");
                SearchResult result = searcher.FindOne();

                if (result == null)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"User not found. Please verify your credentials. {ex.Message}");
            }

            return true;
        }
    }
}
