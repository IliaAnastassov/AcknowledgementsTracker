namespace AcknowledgementsTracker.Business.Interfaces
{
    public interface IUser
    {
        string Username { get; set; }

        string Email { get; set; }

        string Name { get; set; }

        string Team { get; set; }
    }
}
