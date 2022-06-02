using Application.Logic.Employee.Commands.UpdateEmployee;
using Application.Mapping;
using AutoMapper;

namespace WebAPI.RequestDTO.Employee
{
    public class UpdateEmployeeRequestDTO : IMap
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public UpdateEmployeeRequestDTO()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Patronymic = string.Empty;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEmployeeRequestDTO, UpdateEmployeeCommand>();
        }
    }
}
