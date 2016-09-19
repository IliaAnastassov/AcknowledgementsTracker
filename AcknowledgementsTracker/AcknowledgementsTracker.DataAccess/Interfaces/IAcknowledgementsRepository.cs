namespace AcknowledgementsTracker.DataAccess.Interfaces
{
    using System.Collections.Generic;
    using Model;
    using DTO;

    public interface IAcknowledgementsRepository
    {
        void SaveAcknowledgement(AcknowledgementDTO acknowledgementDto);

        void EditAcknowledgement(Acknowledgement acknowledgement);

        void DeleteAcknowledgement(int id);
    }
}
