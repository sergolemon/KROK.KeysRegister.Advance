using Application.Logic.Employee.Commands.CreateEmployee;
using Application.Mapping;
using AutoMapper;

namespace WebAPI.RequestDTO.Employee
{
    public class CreateEmployeeRequestDTO : IMap
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public CreateEmployeeRequestDTO()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Patronymic = string.Empty;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmployeeRequestDTO, CreateEmployeeCommand>();
        }
    }
}
