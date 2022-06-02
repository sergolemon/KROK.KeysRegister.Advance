using Application.Logic.Key.Commands.UpdateKey;
using Application.Mapping;
using AutoMapper;

namespace WebAPI.RequestDTO.Key
{
    public class UpdateKeyRequestDTO : IMap
    {
        public string Name { get; set; }
        public Guid AuditoryTypeId { get; set; }

        public UpdateKeyRequestDTO()
        {
            Name = string.Empty;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateKeyRequestDTO, UpdateKeyCommand>();
        }
    }
}
