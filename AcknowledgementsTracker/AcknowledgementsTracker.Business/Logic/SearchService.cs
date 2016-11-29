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

        public IEnumerable<IUser> FindUsers(string search)
        {
            return LdapAccountManager.Instance.GetUsers(search);
        }

        public IEnumerable<AcknowledgementDTO> FindByKeywords(string search)
        {
            var keywords = textNormalizer.NormalizeText(search)
                                         .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            List<AcknowledgementDTO> acknowledgementDTOs = new List<AcknowledgementDTO>();
            var comparer = new AcknowledgementsDtoComparer();

            if (keywords.Count() == 1)
            {
                List<AcknowledgementDTO> acknowledgementsByUser = new List<AcknowledgementDTO>();

                var usernames = LdapAccountManager.Instance.GetUsers(search)
                                                           .Select(u => u.Username)
                                                           .ToList();

                foreach (var username in usernames)
                {
                    acknowledgementsByUser.AddRange(repository.GetByUsername(username));
                }

                var acknowledgementsByContent = repository.GetByContent(search);
                var acknowledgementsByTag = repository.GetByTag(search);

                // Add all the results
                acknowledgementDTOs.AddRange(acknowledgementsByUser);
                acknowledgementDTOs.AddRange(acknowledgementsByContent);
                acknowledgementDTOs.AddRange(acknowledgementsByTag);

                acknowledgementDTOs = acknowledgementDTOs.Distinct(comparer).ToList();
            }
            else
            {
                foreach (var keyword in keywords)
                {
                    List<AcknowledgementDTO> acknowledgementsByUser = new List<AcknowledgementDTO>();

                    var usernames = LdapAccountManager.Instance.GetUsers(keyword)
                                                               .Select(u => u.Username)
                                                               .ToList();

                    foreach (var username in usernames)
                    {
                        acknowledgementsByUser.AddRange(repository.GetByUsername(username));
                    }

                    var acknowledgementsByContent = repository.GetByContent(keyword);
                    var acknowledgementsByTag = repository.GetByTag(keyword);

                    // Intersect the three into an intersection by keyword
                    var acknowledgementsByKeyword = acknowledgementsByUser.Intersect(
                                                                           acknowledgementsByContent.Intersect(acknowledgementsByTag, comparer),
                                                                           comparer);

                    // On the first word or if no results are found so far, add the intersected result
                    if (acknowledgementDTOs.Count == 0)
                    {
                        acknowledgementDTOs.AddRange(acknowledgementsByKeyword);
                    }
                    // Intersect the previous result with the new intersected result and store it as current
                    else
                    {
                        acknowledgementDTOs = acknowledgementDTOs.Intersect(acknowledgementsByKeyword, comparer)
                                                           .ToList();
                    }
                }
            }

            return acknowledgementDTOs;
        }
    }
}
