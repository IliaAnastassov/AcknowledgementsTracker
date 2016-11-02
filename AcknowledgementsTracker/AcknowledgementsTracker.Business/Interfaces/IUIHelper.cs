namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.Collections.Generic;
    using DTO;

    public interface IUIHelper
    {
        string GetUserFullName(string username);

        IEnumerable<string> GetTags(IEnumerable<TagDTO> tags);
    }
}
