namespace AcknowledgementsTracker.Business.Interfaces
{
    public interface ILoginResponse
    {
        IUser User { get; set; }
        string ErrorMessage { get; set; }
    }
}
