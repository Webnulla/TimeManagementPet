using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;

namespace TimeManagement.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;

        public ClientController(IClientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllClients()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdClient([FromRoute] int id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateClient([FromBody] Client client)
        {
            await _repository.Add(client);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateClient([FromBody] Client client)
        {
            await _repository.Update(client);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            await _repository.Delete(id);
            return Ok();
        }
    }
}
