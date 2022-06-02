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

namespace Application.Logic.AuditoryType.Commands.UpdateAuditoryType
{
    internal class UpdateAuditoryTypeCommandHandler : IRequestHandler<UpdateAuditoryTypeCommand, Unit>
    {
        public UpdateAuditoryTypeCommandHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public async Task<Unit> Handle(UpdateAuditoryTypeCommand request, CancellationToken cancellationToken)
        {
            if (!await _uow.AuditoryTypeRepository.CheckAuditoryTypeExistenceByIdAsync(request.Id))
                throw new NotFoundException(request.Id);
            if (!await _uow.AuditoryTypeRepository.CheckAuditoryTypeUniqueNameAsync(request.Name, request.Id))
                throw new ConflictException("Auditory type must have a unique name.");

            AuditoryTypeEntity entity = _mapper.Map<AuditoryTypeEntity>(request);

            _uow.AuditoryTypeRepository.UpdateAuditoryType(entity);
            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
