namespace AcknowledgementsTracker.Business.Interfaces
{
    public interface ILdapSettingsService
    {
        string Path { get; set; }

        string Username { get; set; }

        string UserPassword { get; set; }
    }
}
