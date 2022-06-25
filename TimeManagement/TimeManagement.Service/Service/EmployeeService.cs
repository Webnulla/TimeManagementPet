using System.Collections.Generic;
using System.Threading.Tasks;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TimeManagement.Service.Service
{
    public class EmployeeService : IService<Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task Create(Employee item)
        {
            await _employeeRepository.Add(item);
        }

        public async Task Update(Employee item)
        {
            var employee = await _employeeRepository.Get(item.Id);
            employee.Id = item.Id;
            employee.FirstName = item.FirstName;
            employee.LastName = item.LastName;
            employee.Phone = item.Phone;
            employee.Tasks = item.Tasks;

            await _employeeRepository.Update(employee);
        }

        public async Task Delete(int id)
        {
            await _employeeRepository.Delete(id);
        }

        public async Task<Employee> Get(int id)
        {
            var employee = await _employeeRepository.Get(id);
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employee = await _employeeRepository.GetAll();
            return employee;
        }
    }
}