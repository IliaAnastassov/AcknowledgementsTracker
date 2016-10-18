namespace AcknowledgementsTracker.Business.Interfaces
{
    using DTO;

    public interface ITagDtoService : IDtoService
    {
        void Create(TagDTO dto);

        TagDTO Read(string title);

        void Update(TagDTO dto);
    }
}
