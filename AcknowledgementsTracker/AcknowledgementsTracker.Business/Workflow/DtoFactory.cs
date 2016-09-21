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
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>
        {
            { typeof(AcknowledgementDTO), new AcknowledgementsRepository() },
            { typeof(EmployeeDTO), new EmployeesRepository() },
            { typeof(TagDTO), new TagsRepository() }
        };

        public object GetRepository(Type keyType)
        {
            try
            {
                return repositories[keyType];
            }
            catch
            {
                return null;
            }
        }

        public IRepository<T> GetRepository<T>() where T : IDto
        {
            Type keyType = typeof(T);
            try
            {
                return (IRepository<T>)repositories[keyType];
            }
            catch
            {
                return null;
            }
        }
    }
}