namespace AcknowledgementsTracker.Assembler
{
    using System.Collections.Generic;
    using DTO;
    using Model;

    public class AcknowledgementDtoAssembler : BaseAssembler<Acknowledgement, AcknowledgementDTO>
    {
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
            dto.Text = entity.Text;

            return dto;
        }

        public override Acknowledgement Disassemble(AcknowledgementDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            var entity = new Acknowledgement();

            entity.AcknowledgementId = dto.Id;
            entity.AuthorUsername = dto.AuthorUsername;
            entity.BeneficiaryUsername = dto.BeneficiaryUsername;
            entity.DateCreated = dto.DateCreated;
            entity.Text = dto.Text;

            return entity;
        }
    }
}
