using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    internal class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> opts) : base(opts)
        {
        }

        public DbSet<EmployeeEntity> Employees { get; set; } = null!;
        public DbSet<KeyEntity> Keys { get; set; } = null!;
        public DbSet<EventEntity> Events { get; set; } = null!;
        public DbSet<AuditoryTypeEntity> AuditoryTypes { get; set; } = null!;
        public DbSet<PermissionEntity> Permissions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }
    }
}
