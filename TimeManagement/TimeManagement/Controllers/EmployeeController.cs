using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;
using TimeManagement.Service.Service;

namespace TimeManagement.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IService<Employee> _service;

        public EmployeeController(IService<Employee> service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdEmployee([FromRoute] int id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            await _service.Create(employee);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            await _service.Update(employee);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
