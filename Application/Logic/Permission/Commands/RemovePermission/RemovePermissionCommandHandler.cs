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

namespace Application.Logic.Permission.Commands.RemovePermission
{
    internal class RemovePermissionCommandHandler : IRequestHandler<RemovePermissionCommand, Unit>
    {
        public RemovePermissionCommandHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public async Task<Unit> Handle(RemovePermissionCommand request, CancellationToken cancellationToken)
        {
            PermissionEntity entity = _mapper.Map<PermissionEntity>(request);

            if (!await _uow.PermissionRepository.CheckPermissionExistenceAsync(entity))
                throw new NotFoundException("Permission has not found.");

            _uow.PermissionRepository.RemovePermission(entity);
            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
