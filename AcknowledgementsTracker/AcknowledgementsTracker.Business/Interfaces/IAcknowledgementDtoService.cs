namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.Collections.Generic;
    using DTO;

    public interface IAcknowledgementDtoService : IDtoService
    {
        void Create(AcknowledgementDTO dto, IEnumerable<string> tags);

        IEnumerable<AcknowledgementDTO> Read(string username);

        void Update(AcknowledgementDTO dto);
    }
}
