using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponseDTO.Employee
{
    public class BaseEmployeeResponseDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public BaseEmployeeResponseDTO()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Patronymic = string.Empty;
        }
    }
}
