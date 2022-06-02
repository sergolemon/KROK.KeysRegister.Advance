using Application.ResponseDTO.Employee;
using Application.ResponseDTO.Key;
using Domain.Constants;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.QueryableExtensions
{
    internal static class EmployeeQueryableExtensions
    {
        public static IQueryable<EmployeeResponseDTO> ProjectToEmployee(this IQueryable<EmployeeEntity> query, EFDbContext context)
        {
            return query.Select(entity => new EmployeeResponseDTO 
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Patronymic = entity.Patronymic,
                HasKeys = entity.Events.Any(ev => 
                    ev.Type.Equals(EventTypeConst.ISSUE) && 
                    !context.Events.Any(_ev => 
                        _ev.Type.Equals(EventTypeConst.RETURN) &&
                        _ev.DateTime > ev.DateTime &&
                        _ev.KeyId == ev.KeyId
                    )
                )
            });
        }

        public static IQueryable<EmployeeDetailsResponseDTO> ProjectToEmployeeDetails(this IQueryable<EmployeeEntity> query, EFDbContext context)
        {
            return query.Select(entity => new EmployeeDetailsResponseDTO
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Patronymic = entity.Patronymic,
                Picture = entity.Picture,
                UsedKeys = entity.Events.Where(ev =>
                    ev.Type.Equals(EventTypeConst.ISSUE) &&
                    !context.Events.Any(_ev =>
                        _ev.Type.Equals(EventTypeConst.RETURN) &&
                        _ev.DateTime > ev.DateTime &&
                        _ev.KeyId == ev.KeyId
                    )
                )
                .Select(ev => new UsedKeyResponseDTO 
                {
                    Id = ev.Key.Id,
                    Name = ev.Key.Name,
                    AuditoryType = ev.Key.AuditoryType.Name,
                    IssueDateTime = ev.DateTime
                })
                .OrderBy(key => key.IssueDateTime)
                .ToList(),
                AllowedKeys = entity.Permissions.Select(per => new KeyResponseDTO 
                {
                    Id = per.Key.Id,
                    Name = per.Key.Name,
                    AuditoryType = per.Key.AuditoryType.Name,
                    IsUsed = per.Key.Events.OrderBy(ev => ev.DateTime).Last().Type == EventTypeConst.ISSUE
                })
                .OrderByDescending(key => key.IsUsed)
                .ThenBy(key => key.AuditoryType)
                .ThenBy(key => key.Name)
                .ToList()
            });
        }
    }
}
