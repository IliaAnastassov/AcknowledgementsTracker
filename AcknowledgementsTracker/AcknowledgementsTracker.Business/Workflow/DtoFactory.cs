namespace AcknowledgementsTracker.Business.Workflow
{
    using System;
    using System.Collections.Generic;
    using DataAccess.Interfaces;
    using DataAccess.Repositories;
    using DTO;
    using DTO.Interfaces;
    using Interfaces;

    public class DtoFactory : IDtoFactory
    {
        private Dictionary<Type, IRepository<IDto>> repositories = new Dictionary<Type, IRepository<IDto>>
        {
            { typeof(AcknowledgementDTO), new AcknowledgementsRepository() },
            { typeof(ProxiadEmployeeDTO), new ProxiadEmployeesRepository() },
            { typeof(TagDTO), new TagsRepository() }
        };

        public IRepository<IDto> GetRepository(Type type)
        {
            return repositories[type];
        }
    }
}
