using Application.Interfaces;
using Application.ResponseDTO.Key;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Key.Queries.GetKeysFreeOnly
{
    internal class GetKeysFreeOnlyQueryHandler : IRequestHandler<GetKeysFreeOnlyQuery, IEnumerable<KeyResponseDTO>>
    {
        public GetKeysFreeOnlyQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private readonly IUnitOfWork _uow;

        public async Task<IEnumerable<KeyResponseDTO>> Handle(GetKeysFreeOnlyQuery request, CancellationToken cancellationToken)
        {
            return await _uow.KeyRepository.GetKeysFreeOnlyAsync(
                (request.Page - 1) * request.Limit,
                request.Limit,
                request.AuditoryTypeId
            );
        }
    }
}
