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

namespace Application.Logic.AuditoryType.Commands.CreateAuditoryType
{
    internal class CreateAuditoryTypeCommandHandler : IRequestHandler<CreateAuditoryTypeCommand, Guid>
    {
        public CreateAuditoryTypeCommandHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public async Task<Guid> Handle(CreateAuditoryTypeCommand request, CancellationToken cancellationToken)
        {
            if (!await _uow.AuditoryTypeRepository.CheckAuditoryTypeUniqueNameAsync(request.Name))
                throw new ConflictException("Auditory type must have a unique name.");

            AuditoryTypeEntity entity = _mapper.Map<AuditoryTypeEntity>(request);
            entity.Id = Guid.NewGuid();

            _uow.AuditoryTypeRepository.CreateAuditoryType(entity);
            await _uow.SaveChangesAsync();

            return entity.Id;
        }
    }
}
