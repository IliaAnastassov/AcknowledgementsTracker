namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using DataAccess.Repositories;
    using DTO;

    public class TagDtoService
    {
        private TagsRepository repository = new TagsRepository();

        public void Create(TagDTO dto)
        {
            repository.Add(dto);
        }

        public void Update(TagDTO dto)
        {
            repository.Edit(dto);
        }

        public void Delete(int id)
        {
            repository.Remove(id);
        }
    }
}
