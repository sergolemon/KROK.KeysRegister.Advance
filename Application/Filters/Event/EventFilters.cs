using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Filters.Event
{
    public class EventFilters
    {
        public Guid? KeyId { get; set; }
        public Guid? EmployeeId { get; set; }
        public DateTime? MinDateTime { get; set; }
        public DateTime? MaxDateTime { get; set; }
        public string? Type { get; set; }
    }
}
