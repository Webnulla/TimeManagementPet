using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;

namespace TimeManagement.Controllers
{
    [Route("api/contract")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractRepository _repository;

        public ContractController(IContractRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllContracts()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdContract([FromRoute] int id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateContract([FromBody] Contract contract)
        {
            await _repository.Add(contract);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateContract([FromBody] Contract contract)
        {
            await _repository.Update(contract);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteContract([FromRoute] int id)
        {
            await _repository.Delete(id);
            return Ok();
        }
    }
}
