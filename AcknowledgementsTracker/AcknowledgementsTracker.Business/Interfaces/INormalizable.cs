namespace AcknowledgementsTracker.Business.Interfaces
{
    public interface INormalizable
    {
        string NormalizeText(string text);

        string RemoveMultiSpaces(string text);
    }
}
