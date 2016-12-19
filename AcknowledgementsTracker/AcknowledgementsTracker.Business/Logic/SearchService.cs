namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using DTO;
    using DataAccess.Repositories;
    using System.Linq;

    public class SearchService : ISearchService
    {
        private AcknowledgementsRepository repository = new AcknowledgementsRepository();
        private INormalizable textNormalizer = new TextNormalizationService();
        private IAccountManager manager;

        public SearchService(ILdapServerConnection connection)
        {
            manager = new LdapAccountManager(connection);
        }

        public IEnumerable<IUser> FindUsers(string search)
        {
            return manager.GetUsers(search);
        }

        public IEnumerable<AcknowledgementDTO> FindByKeywords(string search)
        {
            var keywords = textNormalizer.NormalizeText(search)
                                         .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            List<AcknowledgementDTO> acknowledgementDTOs = new List<AcknowledgementDTO>();
            var comparer = new AcknowledgementsDtoComparer();

            if (keywords.Count() == 1)
            {
                acknowledgementDTOs = FindBySingleKeyword(search);
            }
            else
            {
                acknowledgementDTOs = FindByMultipleKeywords(keywords);
            }

            return acknowledgementDTOs.OrderByDescending(a => a.DateCreated).ToList();
        }

        private List<AcknowledgementDTO> FindBySingleKeyword(string search)
        {
            var results = new List<AcknowledgementDTO>();
            var acknowledgementsByUser = new List<AcknowledgementDTO>();
            var comparer = new AcknowledgementsDtoComparer();
            var usernames = manager.GetUsers(search)
                                   .Select(u => u.Username)
                                   .ToList();

            foreach (var username in usernames)
            {
                acknowledgementsByUser.AddRange(repository.GetByUsername(username));
            }

            var acknowledgementsByContent = repository.GetByContent(search);
            var acknowledgementsByTag = repository.GetByTag(search);

            // Add all the results
            results.AddRange(acknowledgementsByUser);
            results.AddRange(acknowledgementsByContent);
            results.AddRange(acknowledgementsByTag);

            return results.Distinct(comparer).ToList();
        }

        private List<AcknowledgementDTO> FindByMultipleKeywords(string[] keywords)
        {
            var results = new List<AcknowledgementDTO>();
            var comparer = new AcknowledgementsDtoComparer();

            foreach (var keyword in keywords)
            {
                List<AcknowledgementDTO> acknowledgementsByUser = new List<AcknowledgementDTO>();

                var usernames = manager.GetUsers(keyword)
                                       .Select(u => u.Username)
                                       .ToList();

                foreach (var username in usernames)
                {
                    acknowledgementsByUser.AddRange(repository.GetByUsername(username));
                }

                var acknowledgementsByContent = repository.GetByContent(keyword);
                var acknowledgementsByTag = repository.GetByTag(keyword);

                // Union the three into results by keyword
                var acknowledgementsByKeyword = acknowledgementsByUser.Union(
                                                                       acknowledgementsByContent.Union(acknowledgementsByTag, comparer),
                                                                       comparer)
                                                                      .ToList();

                // On the first word or if no results are found so far, add the intersected result
                if (results.Count == 0)
                {
                    results.AddRange(acknowledgementsByKeyword);
                }
                // Intersect the previous result with the new intersected result and store it as current
                else
                {
                    results = results.Intersect(acknowledgementsByKeyword, comparer)
                                     .ToList();
                }
            }

            return results;
        }
    }
}
