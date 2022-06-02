using Application.Logic.Permission.Commands.AddPermission;
using Application.Mapping;
using AutoMapper;

namespace WebAPI.RequestDTO.Permission
{
    public class AddPermissionRequestDTO : IMap
    {
        public Guid KeyId { get; set; }
        public Guid EmployeeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddPermissionRequestDTO, AddPermissionCommand>();
        }
    }
}
