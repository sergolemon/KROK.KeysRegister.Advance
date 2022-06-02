using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class KeyEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AuditoryTypeId { get; set; }
        public AuditoryTypeEntity AuditoryType { get; set; }
        public ICollection<PermissionEntity> Permissions { get; set; }
        public ICollection<EventEntity> Events { get; set; }

        public KeyEntity()
        {
            Name = string.Empty;
            AuditoryType = null!;
            Permissions = new List<PermissionEntity>();
            Events = new List<EventEntity>();
        }
    }
}
