using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmployeeEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public byte[]? Picture { get; set; }
        public ICollection<PermissionEntity> Permissions { get; set; }
        public ICollection<EventEntity> Events { get; set; }

        public EmployeeEntity()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Patronymic = string.Empty;
            Permissions = new List<PermissionEntity>();
            Events = new List<EventEntity>();
        }
    }
}
