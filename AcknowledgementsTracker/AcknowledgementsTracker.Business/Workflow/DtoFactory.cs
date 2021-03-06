﻿namespace AcknowledgementsTracker.Business.Workflow
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
            { typeof(TagDTO), new TagsRepository() }
        };

        public IReadOnlyRepository<T> GetRepository<T>() where T : IDto
        {
            Type keyType = typeof(T);

            try
            {
                return (IReadOnlyRepository<T>)repositories[keyType];
            }
            catch
            {
                return null;
            }
        }

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
    }
}