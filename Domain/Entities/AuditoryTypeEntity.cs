using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AuditoryTypeEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<KeyEntity> Keys { get; set; }

        public AuditoryTypeEntity()
        {
            Name = string.Empty;
            Keys = new List<KeyEntity>();
        }
    }
}
