using Application.Interfaces;
using Application.ResponseDTO.Key;
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
    internal class EFKeyRepository : IKeyRepository
    {
        public EFKeyRepository(EFDbContext context)
        {
            _context = context;
        }

        private readonly EFDbContext _context;

        public void CreateKey(KeyEntity key)
        {
            _context.Keys.Add(key);
        }

        public void UpdateKey(KeyEntity key)
        {
            _context.Keys.Update(key);
        }

        public void DeleteKey(KeyEntity key)
        {
            _context.Keys.Remove(key);
        }

        public async Task<IEnumerable<KeyResponseDTO>> FindKeysByNameAsync(int offset, int limit, string name)
        {
            return await _context.Keys
                .Where(key => key.Name.Contains(name))
                .OrderBy(key => key.Name)
                .Skip(offset)
                .Take(limit)
                .ProjectToKey()
                .ToListAsync();
        }

        public async Task<IEnumerable<KeyResponseDTO>> GetKeysAsync(int offset, int limit, Guid? auditoryTypeId)
        {
            IQueryable<KeyEntity> query = _context.Keys;

            if (auditoryTypeId.HasValue)
                query = query.Where(key => key.AuditoryTypeId == auditoryTypeId);

            return await query
                .OrderBy(key => key.Name)
                .Skip(offset)
                .Take(limit)
                .ProjectToKey()
                .ToListAsync();
        }

        public async Task<IEnumerable<KeyResponseDTO>> GetKeysFreeOnlyAsync(int offset, int limit, Guid? auditoryTypeId)
        {
            IQueryable<KeyEntity> query = _context.Keys;

            if (auditoryTypeId.HasValue)
                query = query.Where(key => key.AuditoryTypeId == auditoryTypeId);

            return await query
                .ProjectToKey()
                .Where(key => !key.IsUsed)
                .OrderBy(key => key.Name)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<KeyPermissionResponseDTO>> FindKeyPermissionsByNameAsync(Guid empId, int offset, int limit, string name)
        {
            return await _context.Keys
                .Where(key => key.Name.Contains(name))
                .OrderBy(key => key.Name)
                .Skip(offset)
                .Take(limit)
                .ProjectToKeyPermission(empId)
                .ToListAsync();
        }

        public async Task<IEnumerable<KeyPermissionResponseDTO>> GetKeyPermissionsAsync(Guid empId, int offset, int limit, Guid? auditoryTypeId)
        {
            IQueryable<KeyEntity> query = _context.Keys;

            if (auditoryTypeId.HasValue)
                query = query.Where(key => key.AuditoryTypeId == auditoryTypeId);

            return await query
                .OrderBy(key => key.Name)
                .Skip(offset)
                .Take(limit)
                .ProjectToKeyPermission(empId)
                .ToListAsync();
        }

        public async Task<KeyDetailsResponseDTO?> GetKeyDetailsOrNullAsync(Guid id)
        {
            return await _context.Keys
                .ProjectToKeyDetails()
                .SingleOrDefaultAsync(key => key.Id == id);
        }

        public async Task<bool> CheckKeyExistenceByIdAsync(Guid id)
        {
            return await _context.Keys
                .AnyAsync(key => key.Id == id);
        }

        public async Task<bool> CheckKeyUniqueNameAsync(string name, Guid? exceptiveKeyId = null)
        {
            return !await _context.Keys
                .AnyAsync(key => key.Id != exceptiveKeyId && key.Name.Equals(name));
        }

        public async Task<IEnumerable<KeyPermissionResponseDTO>> GetKeyPermissionsFreeOnlyAsync(Guid empId, int offset, int limit, Guid? auditoryTypeId)
        {
            IQueryable<KeyEntity> query = _context.Keys;

            if (auditoryTypeId.HasValue)
                query = query.Where(key => key.AuditoryTypeId == auditoryTypeId);

            return await query
                .ProjectToKeyPermission(empId)
                .Where(key => !key.IsUsed)
                .OrderBy(key => key.Name)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }
    }
}
