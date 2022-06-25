using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;
using Task = TimeManagement.Domain.Entities.Task;

namespace TimeManagement.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _repository;

        public TaskController(ITaskRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTask()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdTask([FromRoute] int id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTask([FromBody] Task task)
        {
            await _repository.Add(task);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTask([FromBody] Task task)
        {
            await _repository.Update(task);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            await _repository.Delete(id);
            return Ok();
        }
    }
}
