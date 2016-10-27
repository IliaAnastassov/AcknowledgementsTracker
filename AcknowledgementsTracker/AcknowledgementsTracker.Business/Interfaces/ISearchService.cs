namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.Collections.Generic;
    using DTO;

    public interface ISearchService
    {
        IEnumerable<AcknowledgementDTO> FindAcknowledgements(string search);

        IEnumerable<IUser> FindUsers(string search);
    }
}
