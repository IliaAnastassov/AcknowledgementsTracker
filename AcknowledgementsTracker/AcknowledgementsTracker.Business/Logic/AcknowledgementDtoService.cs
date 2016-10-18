namespace AcknowledgementsTracker.Business.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using DataAccess.Repositories;
    using DTO;
    using Interfaces;

    public class AcknowledgementDtoService : IAcknowledgementDtoService
    {
        private AcknowledgementsRepository repository = new AcknowledgementsRepository();

        public void Create(AcknowledgementDTO dto, IEnumerable<string> tags)
        {
            ////foreach (var tag in tags)
            ////{
            ////    // If tag exists - add the tag to the acknowledgement,
            ////    // else - create new tag and add the new tag to the acknowledgement
            ////    // NOTE: all acknowledgements are stored in lowercase
            ////    var tagDto = tagDtoService.Read(tag.ToLower());

            ////    if (tagDto != null)
            ////    {
            ////        acknowledgementDto.Tags.Add(tagDto);
            ////    }
            ////    else
            ////    {
            ////        var newTagDto = new TagDTO();
            ////        newTagDto.Title = tag.ToLower();

            ////        tagDtoService.Create(newTagDto);

            ////        acknowledgementDto.Tags.Add(newTagDto);
            ////    }
            ////}

            ////repository.Add(dto);
        }

        public IEnumerable<AcknowledgementDTO> Read(string username)
        {
            return repository.GetAcknowledgements(username).ToList();
        }

        public void Update(AcknowledgementDTO dto)
        {
            repository.Edit(dto);
        }

        public void Delete(int id)
        {
            repository.Remove(id);
        }
    }
}
