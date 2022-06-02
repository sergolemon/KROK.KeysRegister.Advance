using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Constants;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic.Event.Commands.AddIssueEvent
{
    internal class AddIssueEventCommandHandler : IRequestHandler<AddIssueEventCommand, Unit>
    {
        public AddIssueEventCommandHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public async Task<Unit> Handle(AddIssueEventCommand request, CancellationToken cancellationToken)
        {
            string? lastEventType = await _uow.EventRepository.GetLastEventTypeForKeyOrNullAsync(request.KeyId);

            if (lastEventType != null && lastEventType != EventTypeConst.RETURN)
                throw new ConflictException("The key has already been issued.");

            if (
                request.EmployeeId.HasValue &&
                !await _uow.PermissionRepository.CheckPermissionExistenceAsync(new PermissionEntity
                {
                    KeyId = request.KeyId,
                    EmployeeId = request.EmployeeId.Value
                })
            ) throw new ConflictException("This employee has not permission for this key.");


            EventEntity entity = _mapper.Map<EventEntity>(request);
            entity.Id = Guid.NewGuid();
            entity.Type = EventTypeConst.ISSUE;
            entity.DateTime = DateTime.Now;

            _uow.EventRepository.CreateEvent(entity);
            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
