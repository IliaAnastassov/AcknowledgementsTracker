namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.Collections.Generic;
    using DTO;

    public interface IAcknowledgementDtoService : IDtoService
    {
        void Create(AcknowledgementDTO dto, IEnumerable<string> tags);

        IEnumerable<AcknowledgementDTO> Read(string username);

        IEnumerable<AcknowledgementDTO> ReadLast();

        IEnumerable<AcknowledgementDTO> ReadTodays();

        IEnumerable<AcknowledgementDTO> ReadThisWeek();

        IEnumerable<AcknowledgementDTO> ReadThisMonth();

        string ReadAllTimeChampion();

        Dictionary<string, int> ReadAllTimeTopTen();

        void Update(AcknowledgementDTO dto);
    }
}
