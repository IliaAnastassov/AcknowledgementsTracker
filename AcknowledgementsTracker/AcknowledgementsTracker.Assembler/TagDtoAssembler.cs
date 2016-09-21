namespace AcknowledgementsTracker.Assembler
{
    using System;
    using DTO;
    using Model;

    public class TagDtoAssembler : BaseAssembler<Tag, TagDTO>
    {
        public override TagDTO Assemble(Tag entity)
        {
            if (entity == null)
            {
                return null;
            }

            var dto = new TagDTO();

            dto.Id = entity.TagId;
            dto.Acknowledgements = entity.Acknowledgements;
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
            tag.Acknowledgements = entity.Acknowledgements;
            tag.Title = entity.Title;

            return tag;
        }
    }
}
