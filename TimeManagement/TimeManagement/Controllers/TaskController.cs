using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;
using TimeManagement.Service.Service;
using Task = TimeManagement.Domain.Entities.Task;

namespace TimeManagement.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IService<Task> _service;

        public TaskController(IService<Task> service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTask()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdTask([FromRoute] int id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTask([FromBody] Task task)
        {
            await _service.Create(task);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTask([FromBody] Task task)
        {
            await _service.Update(task);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
