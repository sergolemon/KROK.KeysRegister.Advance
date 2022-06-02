using Application.ResponseDTO.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponseDTO.Key
{
    public class KeyDetailsResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuditoryType { get; set; }
        public bool IsUsed { get; set; }
        public IEnumerable<BaseEmployeeResponseDTO> AllowedEmployees { get; set; }

        public KeyDetailsResponseDTO()
        {
            Name = string.Empty;
            AuditoryType = string.Empty;
            AllowedEmployees = new List<BaseEmployeeResponseDTO>();
        }
    }
}
