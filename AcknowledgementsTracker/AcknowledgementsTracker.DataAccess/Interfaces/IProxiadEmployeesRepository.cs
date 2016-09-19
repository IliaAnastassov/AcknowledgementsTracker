namespace AcknowledgementsTracker.DataAccess.Interfaces
{
    using Model;

    public interface IProxiadEmployeesRepository
    {
        ProxiadEmployee GetProxiadEmployee(int id);

        ProxiadEmployee GetMostAcknowledgedPersonAllTime();

        ProxiadEmployee GetMostAcknowledgedPersonOfMonth();

        void SaveProxiadEmployee(string userName, string email);

        void EditProxiadEmployee(ProxiadEmployee employee);

        void DeleteProxiadEmployee(int id);
    }
}
