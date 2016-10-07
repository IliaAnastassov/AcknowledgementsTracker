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
            dto.AuthorEmail = entity.AuthorEmail;
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
            acknowledgement.AuthorEmail = entity.AuthorEmail;
            acknowledgement.BeneficiaryEmail = entity.BeneficiaryEmail;
            acknowledgement.DateCreated = entity.DateCreated;
            acknowledgement.Tags = entity.Tags;
            acknowledgement.Text = entity.Text;

            return acknowledgement;
        }
    }
}
