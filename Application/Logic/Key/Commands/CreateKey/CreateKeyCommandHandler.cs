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

namespace Application.Logic.Key.Commands.CreateKey
{
    internal class CreateKeyCommandHandler : IRequestHandler<CreateKeyCommand, Guid>
    {
        public CreateKeyCommandHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public async Task<Guid> Handle(CreateKeyCommand request, CancellationToken cancellationToken)
        {
            if (!await _uow.KeyRepository.CheckKeyUniqueNameAsync(request.Name))
                throw new ConflictException("Key must have a unique name.");

            KeyEntity entity = _mapper.Map<KeyEntity>(request);
            entity.Id = Guid.NewGuid();

            _uow.KeyRepository.CreateKey(entity);
            await _uow.SaveChangesAsync();

            return entity.Id;
        }
    }
}
