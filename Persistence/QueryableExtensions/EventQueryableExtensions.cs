using Application.ResponseDTO.Employee;
using Application.ResponseDTO.Event;
using Application.ResponseDTO.Key;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.QueryableExtensions
{
    internal static class EventQueryableExtensions
    {
        public static IQueryable<EventResponseDTO> ProjectToEvent(this IQueryable<EventEntity> query)
        {
            return query.Select(entity => new EventResponseDTO 
            {
                DateTime = entity.DateTime,
                Type = entity.Type,
                Note = entity.Note,
                Employee = entity.Employee != null ? 
                new BaseEmployeeResponseDTO 
                {
                    Id = entity.Employee.Id,
                    FirstName = entity.Employee.FirstName,
                    LastName = entity.Employee.LastName,
                    Patronymic = entity.Employee.Patronymic
                } :
                null,
                Key = new BaseKeyResponseDTO 
                {
                    Id = entity.Key.Id,
                    Name = entity.Key.Name,
                    AuditoryType = entity.Key.AuditoryType.Name
                }
            });
        }
    }
}
