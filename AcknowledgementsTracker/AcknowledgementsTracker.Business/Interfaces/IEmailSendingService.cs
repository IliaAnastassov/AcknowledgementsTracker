namespace AcknowledgementsTracker.Business.Interfaces
{
    public interface IEmailSendingService
    {
        void SendEmail(IUser author, IUser beneficiary);
    }
}
