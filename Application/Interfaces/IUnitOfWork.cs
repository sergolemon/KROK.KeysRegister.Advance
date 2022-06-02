using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IAuditoryTypeRepository AuditoryTypeRepository { get; }
        public IEventRepository EventRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }
        public IKeyRepository KeyRepository { get; }
        public IPermissionRepository PermissionRepository { get; }

        public Task SaveChangesAsync();
    }
}
