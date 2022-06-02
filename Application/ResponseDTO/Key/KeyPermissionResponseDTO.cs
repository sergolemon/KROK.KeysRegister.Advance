using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponseDTO.Key
{
    public class KeyPermissionResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuditoryType { get; set; }
        public bool IsUsed { get; set; }
        public bool IsAllowedForThisEmployee { get; set; }

        public KeyPermissionResponseDTO()
        {
            Name = string.Empty;
            AuditoryType = string.Empty;
        }
    }
}
