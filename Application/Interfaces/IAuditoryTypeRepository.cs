using Application.ResponseDTO.AuditoryType;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuditoryTypeRepository
    {
        public void CreateAuditoryType(AuditoryTypeEntity auditoryType);
        public void UpdateAuditoryType(AuditoryTypeEntity auditoryType);
        public void DeleteAuditoryType(AuditoryTypeEntity auditoryType);
        public Task<IEnumerable<AuditoryTypeResponseDTO>> GetAllAuditoryTypesAsync();
        public Task<bool> CheckAuditoryTypeExistenceByIdAsync(Guid id);
        public Task<bool> CheckAuditoryTypeUniqueNameAsync(string name, Guid? exceptiveAuditoryTypeId = null);
    }
}
