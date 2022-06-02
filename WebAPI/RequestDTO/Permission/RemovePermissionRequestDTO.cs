using Application.Logic.Permission.Commands.RemovePermission;
using Application.Mapping;
using AutoMapper;

namespace WebAPI.RequestDTO.Permission
{
    public class RemovePermissionRequestDTO : IMap
    {
        public Guid KeyId { get; set; }
        public Guid EmployeeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RemovePermissionRequestDTO, RemovePermissionCommand>();
        }
    }
}
