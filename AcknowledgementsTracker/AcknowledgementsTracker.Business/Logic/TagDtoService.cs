namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using DataAccess.Repositories;
    using DTO;
    using Interfaces;

    public class TagDtoService : ITagDtoService
    {
        private TagsRepository repository = new TagsRepository();

        public void Create(TagDTO dto)
        {
            repository.Add(dto);
        }

        public TagDTO Read(string title)
        {
            return repository.Get(title);
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
