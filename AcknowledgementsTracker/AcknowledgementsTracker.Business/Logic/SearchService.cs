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
            var usernames = accountService.ReadAllUsernames(search);
            return repository.GetByContent(usernames, search);
        }

        public IEnumerable<IUser> FindUsers(string search)
        {
            return LdapAccountManager.Instance.GetUsers(search);
        }
    }
}
