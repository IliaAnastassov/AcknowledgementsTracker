namespace AcknowledgementsTracker.DataAccess.Interfaces
{
    using DTO.Interfaces;
    using System.Collections.Generic;

    public interface IReadOnlyRepository<out T> where T : IDto
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        void Remove(int id);
    }
}
