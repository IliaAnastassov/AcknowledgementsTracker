namespace AcknowledgementsTracker.Business.Interfaces
{
    public interface ILoginService
    {
        ILoginResponse Login(ILdapSettingsService settings);
    }
}
