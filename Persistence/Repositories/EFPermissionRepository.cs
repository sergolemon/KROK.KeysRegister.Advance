using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class EFPermissionRepository : IPermissionRepository
    {
        public EFPermissionRepository(EFDbContext context)
        {
            _context = context;
        }

        private readonly EFDbContext _context;

        public void CreatePermission(PermissionEntity permission)
        {
            _context.Permissions.Add(permission);
        }

        public void RemovePermission(PermissionEntity permission)
        {
            _context.Permissions.Remove(permission);
        }

        public async Task<bool> CheckPermissionExistenceAsync(PermissionEntity permission)
        {
            return await _context.Permissions
                .AnyAsync(per => 
                    per.EmployeeId == permission.EmployeeId && 
                    per.KeyId == permission.KeyId
                );
        }
    }
}
