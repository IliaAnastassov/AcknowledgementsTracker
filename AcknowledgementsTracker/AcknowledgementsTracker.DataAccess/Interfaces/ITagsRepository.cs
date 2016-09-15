namespace AcknowledgementsTracker.DataAccess.Interfaces
{
    using System.Collections.Generic;
    using Model.Models;

    public interface ITagsRepository
    {
        List<Tag> GetTags();

        Tag GetTag(int id);

        void SaveTag(string title);

        void EditTag(Tag tag);

        void DeleteTag(int id);
    }
}
