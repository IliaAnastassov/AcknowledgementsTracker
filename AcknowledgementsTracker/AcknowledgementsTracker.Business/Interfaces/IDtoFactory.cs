namespace AcknowledgementsTracker.Business.Interfaces
{
    using System;
    using DataAccess.Interfaces;
    using DTO.Interfaces;

    public interface IDtoFactory
    {
        IRepository<IDto> GetRepository(Type type);
    }
}
