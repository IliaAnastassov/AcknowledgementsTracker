namespace AcknowledgementsTracker.Buisiness.Contracts
{
    using System.Collections.Generic;

    public interface IModelManager
    {
        void CreateAcknowledgement(string text, int employeeId, List<int> tagIds);

        void CreateProxiadEmployee(string userName, string email);

        void CreateTag(string title);

        void DeleteAcknowledgement();

        void DeleteProxiadEmployee();

        void DeleteTag();

        void EditAcknowledgement();

        void EditProxiadEmployee();

        void EditTag();
    }
}
