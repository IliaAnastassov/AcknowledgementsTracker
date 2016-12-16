namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using DTO;
    using Interfaces;

    public class UIHelper : IUIHelper
    {
        private IAccountService ldapAccountService = new LdapAccountService();

        // TODO: Remove the default constructor, or make
        // sure ldapAccountService.SetAccountManager is always called!
        public UIHelper()
        {
        }

        public UIHelper(ILdapServerConnection connection)
        {
            ldapAccountService.SetAccountManager(connection);
        }

        public string GetUserFullName(string username)
        {
            return ldapAccountService.ReadUserFullName(username);
        }

        public IEnumerable<string> GetTags(IEnumerable<TagDTO> tags)
        {
            var tagTitles = new List<string>();

            foreach (var tag in tags)
            {
                tagTitles.Add(tag.Title);
            }

            return tagTitles;
        }
    }
}
