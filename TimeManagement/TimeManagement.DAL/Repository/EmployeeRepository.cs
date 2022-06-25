using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeManagement.DAL.DataBase;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TimeManagement.DAL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataBaseContext _context;

        public EmployeeRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Employee> Get(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new ArgumentException("Сотрудник не найден");
            }

            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employee = await _context.Employees.ToListAsync();
            return employee;
        }

        public async Task Add(Employee entity)
        {
            await _context.Employees.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee entity)
        {
            var employee = await _context.Employees.FindAsync(entity.Id);
            if (employee == null)
            {
                throw new ArgumentException("Сотрудник не найден");
            }

            employee.Id = entity.Id;
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.Phone = entity.Phone;
            employee.Tasks = entity.Tasks;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new ArgumentException("Сотрудник не найден");
            }

            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}