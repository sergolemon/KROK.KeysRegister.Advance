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

namespace Application.Logic.Permission.Commands.AddPermission
{
    internal class AddPermissionCommandHandler : IRequestHandler<AddPermissionCommand, Unit>
    {
        public AddPermissionCommandHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public async Task<Unit> Handle(AddPermissionCommand request, CancellationToken cancellationToken)
        {
            PermissionEntity entity = _mapper.Map<PermissionEntity>(request);

            if (await _uow.PermissionRepository.CheckPermissionExistenceAsync(entity))
                throw new ConflictException("This permission already exists.");

            _uow.PermissionRepository.CreatePermission(entity);
            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
