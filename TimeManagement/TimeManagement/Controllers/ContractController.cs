using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;
using TimeManagement.Service.Service;

namespace TimeManagement.Controllers
{
    [Route("api/contract")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IService<Contract> _service;

        public ContractController(IService<Contract> service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllContracts()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdContract([FromRoute] int id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateContract([FromBody] Contract contract)
        {
            await _service.Create(contract);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateContract([FromBody] Contract contract)
        {
            await _service.Update(contract);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteContract([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
