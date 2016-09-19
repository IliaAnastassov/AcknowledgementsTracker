namespace AcknowledgementsTracker.DataAccess.Interfaces
{
    using System.Collections.Generic;
    using Model;

    public interface IAcknowledgementsRepository
    {
        void SaveAcknowledgement(Acknowledgement acknowledgement);

        void EditAcknowledgement(Acknowledgement acknowledgement);

        void DeleteAcknowledgement(int id);
    }
}
