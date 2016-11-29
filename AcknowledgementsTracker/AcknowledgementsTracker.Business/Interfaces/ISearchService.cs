namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.Collections.Generic;
    using DTO;

    public interface ISearchService
    {
        IEnumerable<IUser> FindUsers(string search);

        IEnumerable<AcknowledgementDTO> FindByKeywords(string search);
    }
}
