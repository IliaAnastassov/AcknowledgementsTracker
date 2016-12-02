namespace AcknowledgementsTracker.DataAccess.Interfaces
{
    using System.Collections.Generic;
    using DTO;

    public interface IAcknowledgementsRepository : IReadOnlyRepository<AcknowledgementDTO>, IWriteOnlyRepository<AcknowledgementDTO>
    {
        void Add(AcknowledgementDTO acknowledgementDto, IEnumerable<string> tags);

        string GetAllTimeChampion();

        Dictionary<string, int> GetAllTimeTopTen();

        IEnumerable<AcknowledgementDTO> GetByContent(string keyword);

        IEnumerable<AcknowledgementDTO> GetByTag(string tagTitle);

        IEnumerable<AcknowledgementDTO> GetByTagThisMonth(string tagTitle);

        IEnumerable<AcknowledgementDTO> GetByUsername(string username);

        IEnumerable<AcknowledgementDTO> GetGiven(string username);

        IEnumerable<AcknowledgementDTO> GetLastAcknowledgements();

        IEnumerable<AcknowledgementDTO> GetReceived(string username);

        IEnumerable<AcknowledgementDTO> GetThisMonthAcknowledgements();

        IEnumerable<AcknowledgementDTO> GetThisMonthsByUser(string username);

        Dictionary<string, int> GetThisMonthTopTen();

        IEnumerable<AcknowledgementDTO> GetThisWeekAcknowledgements();

        IEnumerable<AcknowledgementDTO> GetTodaysAcknowledgements();

        Dictionary<string, int> GetTopTenUsersByTag(string tagTitle);
    }
}