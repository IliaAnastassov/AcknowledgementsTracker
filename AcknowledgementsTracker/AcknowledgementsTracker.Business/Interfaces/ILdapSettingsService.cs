namespace AcknowledgementsTracker.Business.Interfaces
{
    public interface ILdapSettingsService
    {
        string ServerPath { get; set; }

        string SearchRoot { get; set; }

        string Username { get; set; }

        string Password { get; set; }
    }
}
