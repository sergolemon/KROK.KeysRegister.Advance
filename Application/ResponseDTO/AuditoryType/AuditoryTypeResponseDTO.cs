using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponseDTO.AuditoryType
{
    public class AuditoryTypeResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public AuditoryTypeResponseDTO()
        {
            Name = string.Empty;
        }
    }
}
