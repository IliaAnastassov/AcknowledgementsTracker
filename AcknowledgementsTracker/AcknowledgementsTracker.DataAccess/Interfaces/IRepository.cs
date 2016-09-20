namespace AcknowledgementsTracker.DataAccess.Interfaces
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        void Save(T model);

        void Edit(T model);

        void Delete(int id);
    }
}
