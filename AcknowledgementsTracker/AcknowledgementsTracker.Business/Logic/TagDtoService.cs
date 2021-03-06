﻿namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        public IEnumerable<TagDTO> Read(int acknowledgementid)
        {
            return repository.GetAcknowledgementTags(acknowledgementid).ToList();
        }

        public Dictionary<string, int> ReadMostFrequentTagsAllTime()
        {
            return repository.GetMostFrequentTagsAllTime();
        }

        public Dictionary<string, int> ReadMostFrequentTagsThisMonth()
        {
            return repository.GetMostFrequentTagsThisMonth();
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
