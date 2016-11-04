namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using DTO;
    using DataAccess.Repositories;
    using Interfaces;
    using System.Linq;

    public class SearchService : ISearchService
    {
        private AcknowledgementsRepository repository = new AcknowledgementsRepository();
        private ILdapAccountService accountService = new LdapAccountService();

        public IEnumerable<AcknowledgementDTO> FindAcknowledgements(string search)
        {
            var keywords = search.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> usernames = new List<string>();

            foreach (var keyword in keywords)
            {
                usernames.AddRange(accountService.ReadAllUsernames(keyword));
            }

            return repository.GetByContent(usernames, search);
        }

        public IEnumerable<AcknowledgementDTO> FindAcknowledgementsByTag(string tagTitle)
        {
            return repository.GetByTag(tagTitle);
        }

        public IEnumerable<IUser> FindUsers(string search)
        {
            return LdapAccountManager.Instance.GetUsers(search);
        }
    }
}
