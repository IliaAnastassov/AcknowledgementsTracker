namespace AcknowledgementsTracker.DataAccess.Interfaces
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        void Add(T model);

        void Edit(T model);

        void Remove(int id);
    }
}
