namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.DirectoryServices.AccountManagement;
    using System.Linq;

    public class LdapAccountManager
    {
        private PrincipalContext context;

        public LdapAccountManager(string domainName)
        {
            context = new PrincipalContext(ContextType.Domain, domainName);
        }

        public string GetUserName(string username)
        {
            UserPrincipal user = new UserPrincipal(context);
            UserPrincipal result;
            user.SamAccountName = username;

            using (var searcher = new PrincipalSearcher(user))
            {
                result = (UserPrincipal)searcher.FindOne();
            }

            return result.Name;
        }

        public IEnumerable<string> GetAllUserNames()
        {
            UserPrincipal user = new UserPrincipal(context);
            var names = new List<string>();

            using (var searcher = new PrincipalSearcher(user))
            {
                names.AddRange(searcher.FindAll().Select(r => r.Name));
            }

            return names;
        }
    }
}
