using Application.Interfaces;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    internal class EFUnitOfWork : IUnitOfWork
    {
        public EFUnitOfWork(EFDbContext context)
        {
            _context = context;
        }

        private readonly EFDbContext _context;

        private IPermissionRepository? permissionRepository;
        private IEmployeeRepository? employeeRepository;
        private IEventRepository? eventRepository;
        private IKeyRepository? keyRepository;
        private IAuditoryTypeRepository? auditoryTypeRepository;

        public IAuditoryTypeRepository AuditoryTypeRepository 
        { 
            get 
            {
                if (auditoryTypeRepository == null)
                    auditoryTypeRepository = new EFAuditoryTypeRepository(_context);
                return auditoryTypeRepository;
            }
        }

        public IEventRepository EventRepository
        {
            get
            {
                if (eventRepository == null)
                    eventRepository = new EFEventRepository(_context);
                return eventRepository;
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EFEmployeeRepository(_context);
                return employeeRepository;
            }
        }

        public IKeyRepository KeyRepository
        {
            get
            {
                if (keyRepository == null)
                    keyRepository = new EFKeyRepository(_context);
                return keyRepository;
            }
        }

        public IPermissionRepository PermissionRepository
        {
            get
            {
                if (permissionRepository == null)
                    permissionRepository = new EFPermissionRepository(_context);
                return permissionRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
