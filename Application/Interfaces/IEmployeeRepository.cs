using Application.ResponseDTO.Employee;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEmployeeRepository
    {
        public void CreatEmployee(EmployeeEntity employee);
        public void UpdateEmployee(EmployeeEntity employee);
        public void DeleteEmployee(EmployeeEntity employee);
        public void SetPictureForEmployee(EmployeeEntity employee);
        public Task<IEnumerable<EmployeeResponseDTO>> FindEmployeesByNameAsync(int offset, int limit, string name);
        public Task<IEnumerable<EmployeeResponseDTO>> GetEmployeesAsync(int offset, int limit);
        public Task<IEnumerable<EmployeeResponseDTO>> GetEmployeesWithKeysOnlyAsync(int offset, int limit);
        public Task<EmployeeDetailsResponseDTO?> GetEmployeeDetailsOrNullAsync(Guid id);
        public Task<bool> CheckEmployeeExistenceByIdAsync(Guid id);
    }
}
