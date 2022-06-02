using Application.Interfaces;
using Application.ResponseDTO.Key;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Key.Queries.GetKeyPermissions
{
    internal class GetKeyPermissionsQueryHandler : IRequestHandler<GetKeyPermissionsQuery, IEnumerable<KeyPermissionResponseDTO>>
    {
        public GetKeyPermissionsQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private readonly IUnitOfWork _uow;

        public async Task<IEnumerable<KeyPermissionResponseDTO>> Handle(GetKeyPermissionsQuery request, CancellationToken cancellationToken)
        {
            return await _uow.KeyRepository.GetKeyPermissionsAsync(
                request.EmployeeId,
                (request.Page - 1) * request.Limit,
                request.Limit,
                request.AuditoryTypeId
            );
        }
    }
}
