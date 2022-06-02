using Application.Interfaces;
using Application.ResponseDTO.Key;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Key.Queries.FindKeysByName
{
    internal class FindKeysByNameQueryHandler : IRequestHandler<FindKeysByNameQuery, IEnumerable<KeyResponseDTO>>
    {
        public FindKeysByNameQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private readonly IUnitOfWork _uow;

        public async Task<IEnumerable<KeyResponseDTO>> Handle(FindKeysByNameQuery request, CancellationToken cancellationToken)
        {
            return await _uow.KeyRepository.FindKeysByNameAsync((request.Page - 1) * request.Limit, request.Limit, request.Name);
        }
    }
}
