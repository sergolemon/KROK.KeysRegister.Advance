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

namespace Application.Logic.Event.Commands.AddReturnEvent
{
    internal class AddReturnEventCommandHandler : IRequestHandler<AddReturnEventCommand, Unit>
    {
        public AddReturnEventCommandHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public async Task<Unit> Handle(AddReturnEventCommand request, CancellationToken cancellationToken)
        {
            string? lastEventType = await _uow.EventRepository.GetLastEventTypeForKeyOrNullAsync(request.KeyId);

            if (lastEventType != EventTypeConst.ISSUE)
                throw new ConflictException("The key is already free.");

            EventEntity entity = _mapper.Map<EventEntity>(request);
            entity.Id = Guid.NewGuid();
            entity.DateTime = DateTime.Now;
            entity.Type = EventTypeConst.RETURN;

            _uow.EventRepository.CreateEvent(entity);
            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
