namespace AcknowledgementsTracker.Business.Interfaces
{
    using DTO;
    using DTO.Interfaces;

    public interface ITagDtoService : IDtoService
    {
        void Create(TagDTO dto);

        void Update(TagDTO dto);
    }
}
