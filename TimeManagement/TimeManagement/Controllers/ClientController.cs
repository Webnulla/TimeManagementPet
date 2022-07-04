using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;
using TimeManagement.Service.Service;

namespace TimeManagement.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IService<Client> _service;

        public ClientController(IService<Client> service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllClients()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdClient([FromRoute] int id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateClient([FromBody] Client client)
        {
            await _service.Create(client);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateClient([FromBody] Client client)
        {
            await _service.Update(client);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
