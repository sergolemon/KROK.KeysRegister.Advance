using Application.Interfaces;
using Application.ResponseDTO.Employee;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class EFEmployeeRepository : IEmployeeRepository
    {
        public EFEmployeeRepository(EFDbContext context)
        {
            _context = context;
        }

        private readonly EFDbContext _context;

        public void CreatEmployee(EmployeeEntity employee)
        {
            _context.Employees.Add(employee);
        }

        public void UpdateEmployee(EmployeeEntity employee)
        {
            _context.Employees.Update(employee).Property(emp => emp.Picture).IsModified = false;
        }

        public void DeleteEmployee(EmployeeEntity employee)
        {
            _context.Employees.Remove(employee);
        }

        public void SetPictureForEmployee(EmployeeEntity employee)
        {
            _context.Employees.Attach(employee).Property(emp => emp.Picture).IsModified = true;
        }

        public async Task<IEnumerable<EmployeeResponseDTO>> FindEmployeesByNameAsync(int offset, int limit, string name)
        {
            return await _context.Employees
                .Where(emp => (emp.LastName + " " + emp.FirstName + " " + emp.Patronymic).Contains(name))
                .OrderBy(emp => emp.LastName + emp.FirstName + emp.Patronymic)
                .Skip(offset)
                .Take(limit)
                .ProjectToEmployee(_context)
                .ToListAsync();
        }

        public async Task<IEnumerable<EmployeeResponseDTO>> GetEmployeesAsync(int offset, int limit)
        {
            return await _context.Employees
                .OrderBy(emp => emp.LastName + emp.FirstName + emp.Patronymic)
                .Skip(offset)
                .Take(limit)
                .ProjectToEmployee(_context)
                .ToListAsync();
        }

        public async Task<IEnumerable<EmployeeResponseDTO>> GetEmployeesWithKeysOnlyAsync(int offset, int limit)
        {
            return await _context.Employees
                .ProjectToEmployee(_context)
                .Where(emp => emp.HasKeys)
                .OrderBy(emp => emp.LastName + emp.FirstName + emp.Patronymic)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<EmployeeDetailsResponseDTO?> GetEmployeeDetailsOrNullAsync(Guid id)
        {
            return await _context.Employees
                .ProjectToEmployeeDetails(_context)
                .SingleOrDefaultAsync(emp => emp.Id == id);
        }

        public async Task<bool> CheckEmployeeExistenceByIdAsync(Guid id)
        {
            return await _context.Employees
                .AnyAsync(emp => emp.Id == id);
        }
    }
}
