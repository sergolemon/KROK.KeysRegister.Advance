using Application.ResponseDTO.AuditoryType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.AuditoryType.Queries.GetAllAuditoryTypes
{
    public class GetAllAuditoryTypesQuery : IRequest<IEnumerable<AuditoryTypeResponseDTO>>
    {
    }
}
