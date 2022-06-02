using Application.ResponseDTO.Key;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponseDTO.Employee
{
    public class EmployeeDetailsResponseDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public byte[]? Picture { get; set; }
        public IEnumerable<KeyResponseDTO> AllowedKeys { get; set; }
        public IEnumerable<UsedKeyResponseDTO> UsedKeys { get; set; }

        public EmployeeDetailsResponseDTO()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Patronymic = string.Empty;
            AllowedKeys = new List<KeyResponseDTO>();
            UsedKeys = new List<UsedKeyResponseDTO>();
        }
    }
}
