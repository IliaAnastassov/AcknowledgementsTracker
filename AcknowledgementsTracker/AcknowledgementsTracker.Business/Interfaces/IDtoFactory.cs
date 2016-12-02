namespace AcknowledgementsTracker.Business.Interfaces
{
    using System;
    using DataAccess.Interfaces;
    using DTO.Interfaces;

    public interface IDtoFactory
    {
        IReadOnlyRepository<T> GetRepository<T>() where T : IDto;
        object GetRepository(Type t);
    }
}
