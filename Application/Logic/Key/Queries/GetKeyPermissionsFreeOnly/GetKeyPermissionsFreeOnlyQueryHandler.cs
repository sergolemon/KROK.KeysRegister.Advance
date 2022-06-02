using Application.Interfaces;
using Application.ResponseDTO.Key;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Key.Queries.GetKeyPermissionsFreeOnly
{
    internal class GetKeyPermissionsFreeOnlyQueryHandler : IRequestHandler<GetKeyPermissionsFreeOnlyQuery, IEnumerable<KeyPermissionResponseDTO>>
    {
        public GetKeyPermissionsFreeOnlyQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private readonly IUnitOfWork _uow;

        public async Task<IEnumerable<KeyPermissionResponseDTO>> Handle(GetKeyPermissionsFreeOnlyQuery request, CancellationToken cancellationToken)
        {
            return await _uow.KeyRepository.GetKeyPermissionsFreeOnlyAsync(
                request.EmployeeId,
                (request.Page - 1) * request.Limit,
                request.Limit,
                request.AuditoryTypeId
            );
        }
    }
}
