using Application.Interfaces;
using Application.ResponseDTO.AuditoryType;
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
    internal class EFAuditoryTypeRepository : IAuditoryTypeRepository
    {
        public EFAuditoryTypeRepository(EFDbContext context)
        {
            _context = context;
        }

        private readonly EFDbContext _context;

        public void CreateAuditoryType(AuditoryTypeEntity auditoryType)
        {
            _context.AuditoryTypes.Add(auditoryType);
        }

        public void UpdateAuditoryType(AuditoryTypeEntity auditoryType)
        {
            _context.AuditoryTypes.Update(auditoryType);
        }

        public void DeleteAuditoryType(AuditoryTypeEntity auditoryType)
        {
            _context.AuditoryTypes.Remove(auditoryType);
        }

        public async Task<IEnumerable<AuditoryTypeResponseDTO>> GetAllAuditoryTypesAsync()
        {
            return await _context.AuditoryTypes
                .OrderBy(at => at.Name)
                .ProjectToAuditoryType()
                .ToListAsync();
        }

        public async Task<bool> CheckAuditoryTypeExistenceByIdAsync(Guid id)
        {
            return await _context.AuditoryTypes
                .AnyAsync(at => at.Id == id);
        }

        public async Task<bool> CheckAuditoryTypeUniqueNameAsync(string name, Guid? exceptiveKeyId = null)
        {
            return !await _context.AuditoryTypes
                .AnyAsync(at => at.Id != exceptiveKeyId && at.Name.Equals(name));
        }
    }
}
