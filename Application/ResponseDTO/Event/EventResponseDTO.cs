using Application.ResponseDTO.Employee;
using Application.ResponseDTO.Key;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponseDTO.Event
{
    public class EventResponseDTO
    {
        public DateTime DateTime { get; set; }
        public string Type { get; set; }
        public string? Note { get; set; }
        public BaseEmployeeResponseDTO? Employee { get; set; }
        public BaseKeyResponseDTO Key { get; set; }

        public EventResponseDTO()
        {
            Type = string.Empty;
            Key = null!;
        }
    }
}
