using Application.Interfaces;
using Application.ResponseDTO.Key;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Key.Queries.FindKeyPermissionsByName
{
    internal class FindKeyPermissionsByNameQueryHandler : IRequestHandler<FindKeyPermissionsByNameQuery, IEnumerable<KeyPermissionResponseDTO>>
    {
        public FindKeyPermissionsByNameQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private readonly IUnitOfWork _uow;

        public async Task<IEnumerable<KeyPermissionResponseDTO>> Handle(FindKeyPermissionsByNameQuery request, CancellationToken cancellationToken)
        {
            return await _uow.KeyRepository.FindKeyPermissionsByNameAsync(
                request.EmployeeId,
                (request.Page - 1) * request.Limit,
                request.Limit,
                request.Name
            );
        }
    }
}
