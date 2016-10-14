namespace AcknowledgementsTracker.Assembler
{
    using System;
    using DTO;
    using Model;

    public class AcknowledgementDtoAssembler : BaseAssembler<Acknowledgement, AcknowledgementDTO>
    {
        public AcknowledgementDtoAssembler()
        {
        }

        public override AcknowledgementDTO Assemble(Acknowledgement entity)
        {
            if (entity == null)
            {
                return null;
            }

            var dto = new AcknowledgementDTO();

            dto.Id = entity.AcknowledgementId;
            dto.AuthorUsername = entity.AuthorUsername;
            dto.DateCreated = entity.DateCreated;
            dto.Tags = entity.Tags;
            dto.Text = entity.Text;

            return dto;
        }

        public override Acknowledgement Disassemble(AcknowledgementDTO entity)
        {
            if (entity == null)
            {
                return null;
            }

            var acknowledgement = new Acknowledgement();

            acknowledgement.AcknowledgementId = entity.Id;
            acknowledgement.AuthorUsername = entity.AuthorUsername;
            acknowledgement.BeneficiaryUsername = entity.BeneficiaryUsername;
            acknowledgement.DateCreated = entity.DateCreated;
            acknowledgement.Tags = entity.Tags;
            acknowledgement.Text = entity.Text;

            return acknowledgement;
        }
    }
}
