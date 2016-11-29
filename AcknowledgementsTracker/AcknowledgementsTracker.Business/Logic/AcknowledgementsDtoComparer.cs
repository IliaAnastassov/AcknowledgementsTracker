namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using DTO;

    public class AcknowledgementsDtoComparer : IEqualityComparer<AcknowledgementDTO>
    {
        public bool Equals(AcknowledgementDTO x, AcknowledgementDTO y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(AcknowledgementDTO acknowledgementDto)
        {
            return acknowledgementDto == null ? 0 : acknowledgementDto.Id;
        }
    }
}
