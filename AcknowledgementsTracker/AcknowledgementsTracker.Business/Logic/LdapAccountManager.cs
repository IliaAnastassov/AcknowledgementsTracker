namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.DirectoryServices;
    using System.Linq;
    using Entities;
    using Interfaces;

    public class LdapAccountManager
    {
        private string username;
        private static LdapAccountManager instance;

        public static LdapAccountManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LdapAccountManager();
                }
                return instance;
            }
        }

        private LdapAccountManager()
        {
        }

        public void Setup(string username, string password)
        {
            // TODO: ?
        }

        public void Destroy()
        {
            if (instance != null)
            {
                instance = null;
            }
        }

        public string GetUserName()
        {
            var searcher = new DirectorySearcher();
            searcher.Filter = $"(uid={username})";

            var searchedProperty = "cn";
            searcher.PropertiesToLoad.Add(searchedProperty);

            var result = searcher.FindOne();

            if (result != null)
            {
                return result.Properties[searchedProperty].ToString();
            }

            return null;
        }

        public string GetUserEmail()
        {
            var searcher = new DirectorySearcher();
            searcher.Filter = $"(uid={username})";

            var searchedProperty = "mail";
            searcher.PropertiesToLoad.Add(searchedProperty);

            var result = searcher.FindOne();

            if (result != null)
            {
                return result.Properties[searchedProperty].ToString();
            }

            return null;
        }

        public IEnumerable<IUser> GetAllUsersData()
        {
            // TODO:
            return null;
        }
    }
}
