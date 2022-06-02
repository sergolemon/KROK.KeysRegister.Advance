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

namespace Application.Logic.AuditoryType.Commands.DeleteAuditoryType
{
    internal class DeleteAuditoryTypeCommandHandler : IRequestHandler<DeleteAuditoryTypeCommand, Unit>
    {
        public DeleteAuditoryTypeCommandHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public async Task<Unit> Handle(DeleteAuditoryTypeCommand request, CancellationToken cancellationToken)
        {
            if (!await _uow.AuditoryTypeRepository.CheckAuditoryTypeExistenceByIdAsync(request.Id))
                throw new NotFoundException(request.Id);

            AuditoryTypeEntity entity = _mapper.Map<AuditoryTypeEntity>(request);

            _uow.AuditoryTypeRepository.DeleteAuditoryType(entity);
            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
