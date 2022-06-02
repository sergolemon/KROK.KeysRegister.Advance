using Application.ResponseDTO.Key;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Key.Queries.GetKeysFreeOnly
{
    public class GetKeysFreeOnlyQuery : IRequest<IEnumerable<KeyResponseDTO>>
    {
        public Guid? AuditoryTypeId { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }

        public GetKeysFreeOnlyQuery()
        {
            Page = 1;
            Limit = 10;
        }
    }
}
