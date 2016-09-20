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
        DtoFactory factory = new DtoFactory();

        public void Create(IDto dto)
        {
            var repository = factory.GetRepository(dto.GetType());
            repository.Save(dto);
        }
    }
}
