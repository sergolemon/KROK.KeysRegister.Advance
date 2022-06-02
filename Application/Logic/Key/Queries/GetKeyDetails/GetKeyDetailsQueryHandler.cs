using Application.Exceptions;
using Application.Interfaces;
using Application.ResponseDTO.Key;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Key.Queries.GetKeyDetails
{
    internal class GetKeyDetailsQueryHandler : IRequestHandler<GetKeyDetailsQuery, KeyDetailsResponseDTO>
    {
        public GetKeyDetailsQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private readonly IUnitOfWork _uow;

        public async Task<KeyDetailsResponseDTO> Handle(GetKeyDetailsQuery request, CancellationToken cancellationToken)
        {
            KeyDetailsResponseDTO? response = await _uow.KeyRepository.GetKeyDetailsOrNullAsync(request.Id);

            if (response == null)
                throw new NotFoundException(request.Id);

            return response;
        }
    }
}
