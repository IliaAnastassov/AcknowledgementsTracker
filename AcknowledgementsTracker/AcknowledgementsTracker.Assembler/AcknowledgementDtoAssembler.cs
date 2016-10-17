namespace AcknowledgementsTracker.Assembler
{
    using System.Collections.Generic;
    using DTO;
    using Model;

    public class AcknowledgementDtoAssembler : BaseAssembler<Acknowledgement, AcknowledgementDTO>
    {
        private DtoSubCollectionAssembler collectionAssembler = new DtoSubCollectionAssembler();

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
            dto.Tags = (ICollection<TagDTO>)collectionAssembler.AssembleSubCollection(entity.Tags);
            dto.Text = entity.Text;

            return dto;
        }

        public override Acknowledgement Disassemble(AcknowledgementDTO entity)
        {
            if (entity == null)
            {
                return null;
            }

            var dto = new Acknowledgement();

            dto.AcknowledgementId = entity.Id;
            dto.AuthorUsername = entity.AuthorUsername;
            dto.BeneficiaryUsername = entity.BeneficiaryUsername;
            dto.DateCreated = entity.DateCreated;
            dto.Tags = (ICollection<Tag>)collectionAssembler.DisassembleSubCollection(entity.Tags);
            dto.Text = entity.Text;

            return dto;
        }
    }
}
