using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EventEntity
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Type { get; set; }
        public string? Note { get; set; }
        public Guid? EmployeeId { get; set; }
        public EmployeeEntity? Employee { get; set; }
        public Guid KeyId { get; set; }
        public KeyEntity Key { get; set; }

        public EventEntity()
        {
            Type = string.Empty;
            Key = null!;
        }
    }
}
