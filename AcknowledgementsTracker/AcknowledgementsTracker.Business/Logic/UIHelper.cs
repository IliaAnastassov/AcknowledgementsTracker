namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using DTO;
    using Interfaces;

    public class UIHelper : IUIHelper
    {
        private ILdapAccountService ldapAccountService = new LdapAccountService();

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
