namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using DataAccess.Interfaces;
    using DataAccess.Repositories;
    using DTO;
    using DTO.Interfaces;
    using Workflow;

    public class ModelService
    {
        private DtoFactory factory = new DtoFactory();

        public void Create(IDto dto)
        {
            var repository = factory.GetRepository(dto.GetType());
            repository.Add(dto);
        }

        public void Update(IDto dto)
        {
            var repository = factory.GetRepository(dto.GetType());
            repository.Edit(dto);
        }

        public void Delete(IDto dto)
        {
            var repository = factory.GetRepository(dto.GetType());
            repository.Remove(dto.Id);
        }
    }
}
