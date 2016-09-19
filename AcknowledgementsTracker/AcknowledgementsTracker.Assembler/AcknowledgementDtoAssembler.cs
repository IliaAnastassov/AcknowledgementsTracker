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

            dto.Id = entity.Id;
            dto.Author = entity.Author;
            dto.AuthorId = entity.AuthorId;
            dto.Beneficiary = entity.Beneficiary;
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

            acknowledgement.Id = entity.Id;
            acknowledgement.Author = entity.Author;
            acknowledgement.AuthorId = entity.AuthorId;
            acknowledgement.Beneficiary = entity.Beneficiary;
            acknowledgement.BeneficiaryId = entity.BeneficiaryId;
            acknowledgement.DateCreated = entity.DateCreated;
            acknowledgement.Tags = entity.Tags;
            acknowledgement.Text = entity.Text;

            return acknowledgement;
        }
    }
}
