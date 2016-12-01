namespace AcknowledgementsTracker.Business.Interfaces
{
    public interface ILoginResponse
    {
        IUser User { get; set; }
        string ResponseMessage { get; set; }
    }
}
