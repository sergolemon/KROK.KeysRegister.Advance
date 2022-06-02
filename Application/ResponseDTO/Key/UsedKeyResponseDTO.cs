using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponseDTO.Key
{
    public class UsedKeyResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuditoryType { get; set; }
        public DateTime IssueDateTime { get; set; }

        public UsedKeyResponseDTO()
        {
            AuditoryType = string.Empty;
            Name = string.Empty;
        }
    }
}
