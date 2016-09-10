namespace AcknowledgementsTracker.Buisiness.Contracts
{
    public interface IModelManager
    {
        void CreateAcknowledgement(string text, int id);

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
