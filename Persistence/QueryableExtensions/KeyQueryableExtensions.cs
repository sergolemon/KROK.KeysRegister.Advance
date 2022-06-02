using Application.ResponseDTO.Key;
using Application.ResponseDTO.Employee;
using Domain.Entities;
using Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.QueryableExtensions
{
    internal static class KeyQueryableExtensions
    {

        public static IQueryable<KeyResponseDTO> ProjectToKey(this IQueryable<KeyEntity> query)
        {
            return query.Select(entity => new KeyResponseDTO 
            {
                Id = entity.Id,
                Name = entity.Name,
                AuditoryType = entity.AuditoryType.Name,
                IsUsed = entity.Events.OrderBy(ev => ev.DateTime).Last().Type == EventTypeConst.ISSUE
            });
        }

        public static IQueryable<KeyDetailsResponseDTO> ProjectToKeyDetails(this IQueryable<KeyEntity> query)
        {
            return query.Select(entity => new KeyDetailsResponseDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                AuditoryType = entity.AuditoryType.Name,
                IsUsed = entity.Events.OrderBy(ev => ev.DateTime).Last().Type == EventTypeConst.ISSUE,
                AllowedEmployees = entity.Permissions.Select(per => new BaseEmployeeResponseDTO 
                {
                    Id = per.Employee.Id,
                    FirstName = per.Employee.FirstName,
                    LastName = per.Employee.LastName,
                    Patronymic = per.Employee.Patronymic
                })
                .OrderBy(emp => emp.LastName + emp.FirstName + emp.Patronymic)
                .ToList()
            });
        }

        public static IQueryable<KeyPermissionResponseDTO> ProjectToKeyPermission(this IQueryable<KeyEntity> query, Guid empId)
        {
            return query.Select(entity => new KeyPermissionResponseDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                AuditoryType = entity.AuditoryType.Name, 
                IsUsed = entity.Events.OrderBy(ev => ev.DateTime).Last().Type == EventTypeConst.ISSUE,
                IsAllowedForThisEmployee = entity.Permissions.Any(per => per.EmployeeId == empId)
            });
        }
    }
}
