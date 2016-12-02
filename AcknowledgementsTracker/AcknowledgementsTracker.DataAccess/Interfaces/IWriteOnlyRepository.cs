namespace AcknowledgementsTracker.DataAccess.Interfaces
{
    using DTO.Interfaces;

    public interface IWriteOnlyRepository<in T> where T : IDto
    {
        void Add(T model);

        void Edit(T model);
    }
}
