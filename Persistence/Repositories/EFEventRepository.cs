using Application.Filters.Event;
using Application.Interfaces;
using Application.ResponseDTO.Event;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class EFEventRepository : IEventRepository
    {
        public EFEventRepository(EFDbContext context)
        {
            _context = context;
        }

        private readonly EFDbContext _context;

        public void CreateEvent(EventEntity @event)
        {
            _context.Events.Add(@event);
        }

        public async Task<IEnumerable<EventResponseDTO>> GetEventsAsync(int offset, int limit, EventFilters? filters)
        {
            IQueryable<EventEntity> query = _context.Events;

            if(filters != null)
            {
                if (!string.IsNullOrEmpty(filters.Type))
                    query = query.Where(ev => ev.Type == filters.Type);
                if (filters.MinDateTime.HasValue)
                    query = query.Where(ev => ev.DateTime > filters.MinDateTime);
                if (filters.MaxDateTime.HasValue)
                    query = query.Where(ev => ev.DateTime < filters.MaxDateTime);
                if (filters.EmployeeId.HasValue)
                    query = query.Where(ev => ev.EmployeeId == filters.EmployeeId);
                if (filters.KeyId.HasValue)
                    query = query.Where(ev => ev.KeyId == filters.KeyId);
            }

            return await query
                .OrderByDescending(ev => ev.DateTime)
                .Skip(offset)
                .Take(limit)
                .ProjectToEvent()
                .ToListAsync();
        }

        public async Task<string?> GetLastEventTypeForKeyOrNullAsync(Guid keyId)
        {
            return await _context.Events
                .Where(ev => ev.KeyId == keyId)
                .OrderBy(ev => ev.DateTime)
                .Select(ev => ev.Type)
                .LastOrDefaultAsync();
        }
    }
}
