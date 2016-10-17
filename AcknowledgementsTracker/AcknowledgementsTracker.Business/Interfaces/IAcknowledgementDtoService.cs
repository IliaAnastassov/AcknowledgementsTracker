namespace AcknowledgementsTracker.Business.Interfaces
{
    using DTO;
    using DTO.Interfaces;

    public interface IAcknowledgementDtoService : IDtoService
    {
        void Create(AcknowledgementDTO dto);

        void Update(AcknowledgementDTO dto);
    }
}
