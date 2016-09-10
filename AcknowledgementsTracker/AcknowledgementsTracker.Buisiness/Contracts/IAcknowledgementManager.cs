namespace AcknowledgementsTracker.Buisiness.Contracts
{
    public interface IAcknowledgementManager
    {
        void CreateAcknowledgement();

        void EditAcknowledgement();

        void DeleteAcknowledgement();

        void AddTag();
    }
}
