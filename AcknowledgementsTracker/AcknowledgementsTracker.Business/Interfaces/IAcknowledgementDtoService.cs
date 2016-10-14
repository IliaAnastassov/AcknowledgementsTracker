namespace AcknowledgementsTracker.Business.Interfaces
{
    using DTO;

    public interface IAcknowledgementDtoService
    {
        void Create(AcknowledgementDTO dto);

        void Update(AcknowledgementDTO dto);

        void Delete(int id);
    }
}
