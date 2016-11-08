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
        private ILdapAccountService accountService = new LdapAccountService();
        private INormalizable textNormalizer = new TextNormalizationService();

        public IEnumerable<AcknowledgementDTO> FindAcknowledgements(string search)
        {
            search = textNormalizer.NormalizeText(search);

            var keywords = search.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> usernames = new List<string>();

            foreach (var keyword in keywords)
            {
                usernames.AddRange(accountService.ReadAllUsernames(keyword));
            }

            return repository.GetByContent(usernames, search);
        }

        public IEnumerable<IUser> FindUsers(string search)
        {
            return LdapAccountManager.Instance.GetUsers(search);
        }
    }
}
