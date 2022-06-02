using Application.ResponseDTO.Key;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Key.Queries.GetKeyPermissionsFreeOnly
{
    public class GetKeyPermissionsFreeOnlyQuery : IRequest<IEnumerable<KeyPermissionResponseDTO>>
    {
        public Guid EmployeeId { get; set; }
        public Guid? AuditoryTypeId { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }

        public GetKeyPermissionsFreeOnlyQuery()
        {
            Page = 1;
            Limit = 10;
        }
    }
}
