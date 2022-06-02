using Application.Interfaces;
using Application.ResponseDTO.Key;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Key.Queries.GetKeys
{
    internal class GetKeysQueryHandler : IRequestHandler<GetKeysQuery, IEnumerable<KeyResponseDTO>>
    {
        public GetKeysQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private readonly IUnitOfWork _uow;

        public async Task<IEnumerable<KeyResponseDTO>> Handle(GetKeysQuery request, CancellationToken cancellationToken)
        {
            return await _uow.KeyRepository.GetKeysAsync((request.Page - 1) * request.Limit, request.Limit, request.AuditoryTypeId);
        }
    }
}
