using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Key.Commands.UpdateKey
{
    internal class UpdateKeyCommandHandler : IRequestHandler<UpdateKeyCommand, Unit>
    {
        public UpdateKeyCommandHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public async Task<Unit> Handle(UpdateKeyCommand request, CancellationToken cancellationToken)
        {
            if (!await _uow.KeyRepository.CheckKeyExistenceByIdAsync(request.Id))
                throw new NotFoundException(request.Id);
            if (!await _uow.KeyRepository.CheckKeyUniqueNameAsync(request.Name, request.Id))
                throw new ConflictException("Key must have a unique name.");

            KeyEntity entity = _mapper.Map<KeyEntity>(request);

            _uow.KeyRepository.UpdateKey(entity);
            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
