namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using DTO;
    using DataAccess.Repositories;

    public class SearchService : ISearchService
    {
        private AcknowledgementsRepository repository = new AcknowledgementsRepository();
        private IAccountService accountService = new LdapAccountService();
        private INormalizable textNormalizer = new TextNormalizationService();

        public IEnumerable<AcknowledgementDTO> FindAcknowledgements(IEnumerable<IUser> users, string search)
        {
            search = textNormalizer.NormalizeText(search);
            List<string> usernames = new List<string>();

            foreach (var user in users)
            {
                usernames.Add(user.Username);
            }

            var acknowledgements = repository.GetByContent(usernames, search);
            return acknowledgements;
        }

        public IEnumerable<IUser> FindUsers(string search)
        {
            var users = LdapAccountManager.Instance.GetUsers(search);
            return users;
        }
    }
}
