namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.Collections.Generic;
    using DTO;

    public interface ITagDtoService : IDtoService
    {
        void Create(TagDTO dto);

        TagDTO Read(string title);

        IEnumerable<TagDTO> Read(int acknowledgementid);

        Dictionary<string, int> ReadMostFrequentTagsAllTime();

        Dictionary<string, int> ReadMostFrequentTagsThisMonth();

        void Update(TagDTO dto);
    }
}
