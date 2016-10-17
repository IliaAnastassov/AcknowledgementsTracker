namespace AcknowledgementsTracker.Assembler
{
    using System.Collections.Generic;
    using DTO;
    using Model;

    public class TagDtoAssembler : BaseAssembler<Tag, TagDTO>
    {
        private DtoSubCollectionAssembler collectionAssembler = new DtoSubCollectionAssembler();

        public override TagDTO Assemble(Tag entity)
        {
            if (entity == null)
            {
                return null;
            }

            var dto = new TagDTO();

            dto.Id = entity.TagId;
            dto.Acknowledgements = (ICollection<AcknowledgementDTO>)collectionAssembler.AssembleSubCollection(entity.Acknowledgements);
            dto.Title = entity.Title;

            return dto;
        }

        public override Tag Disassemble(TagDTO entity)
        {
            if (entity == null)
            {
                return null;
            }

            var tag = new Tag();

            tag.TagId = entity.Id;
            tag.Acknowledgements = (ICollection<Acknowledgement>)collectionAssembler.DisassembleSubCollection(entity.Acknowledgements);
            tag.Title = entity.Title;

            return tag;
        }
    }
}
