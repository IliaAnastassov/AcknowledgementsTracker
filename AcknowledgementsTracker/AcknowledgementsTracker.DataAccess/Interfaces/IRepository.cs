namespace AcknowledgementsTracker.DataAccess.Interfaces
{
    using DTO.Interfaces;
    using System.Collections.Generic;

    public interface IRepository<T>
        where T : IDto
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        void Add(T model);

        void Edit(T model);

        void Remove(int id);
    }
}
