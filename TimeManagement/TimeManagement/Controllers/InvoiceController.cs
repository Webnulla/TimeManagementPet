using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;

namespace TimeManagement.Controllers
{
    [Route("api/invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _repository;

        public InvoiceController(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllInvoices()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdInvoice([FromRoute] int id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
        {
            await _repository.Add(invoice);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateInvoice([FromBody] Invoice invoice)
        {
            await _repository.Update(invoice);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteInvoice([FromRoute] int id)
        {
            await _repository.Delete(id);
            return Ok();
        }
    }
}
