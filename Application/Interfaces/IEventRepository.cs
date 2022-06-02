using Application.Filters.Event;
using Application.ResponseDTO.Event;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEventRepository
    {
        public void CreateEvent(EventEntity @event);
        public Task<IEnumerable<EventResponseDTO>> GetEventsAsync(int offset, int limit, EventFilters? filters);
        public Task<string?> GetLastEventTypeForKeyOrNullAsync(Guid keyId);
    }
}
