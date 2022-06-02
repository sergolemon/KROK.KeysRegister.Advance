using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPermissionRepository
    {
        public void CreatePermission(PermissionEntity permission);
        public void RemovePermission(PermissionEntity permission);
        public Task<bool> CheckPermissionExistenceAsync(PermissionEntity permission);
    }
}
