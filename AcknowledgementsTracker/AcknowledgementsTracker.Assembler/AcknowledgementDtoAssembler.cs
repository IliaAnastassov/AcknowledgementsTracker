namespace AcknowledgementsTracker.Assembler
{
    using System.Collections.Generic;
    using DTO;
    using Model;

    public class AcknowledgementDtoAssembler : BaseAssembler<Acknowledgement, AcknowledgementDTO>
    {
        private DtoSubCollectionAssembler collectionAssembler = new DtoSubCollectionAssembler();

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
            dto.Tags = (ICollection<TagDTO>)collectionAssembler.AssembleSubCollection(entity.Tags);

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
            entity.Tags = (ICollection<Tag>)collectionAssembler.DisassembleSubCollection(dto.Tags);

            return entity;
        }
    }
}
