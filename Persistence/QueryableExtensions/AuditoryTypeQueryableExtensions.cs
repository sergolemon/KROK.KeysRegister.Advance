using Application.ResponseDTO.AuditoryType;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.QueryableExtensions
{
    internal static class AuditoryTypeQueryableExtensions
    {
        public static IQueryable<AuditoryTypeResponseDTO> ProjectToAuditoryType(this IQueryable<AuditoryTypeEntity> query)
        {
            return query.Select(entity => new AuditoryTypeResponseDTO 
            {
                Id = entity.Id,
                Name = entity.Name
            });
        }
    }
}
