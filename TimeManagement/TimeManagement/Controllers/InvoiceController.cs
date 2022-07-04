using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;
using TimeManagement.Service.Service;

namespace TimeManagement.Controllers
{
    [Route("api/invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IService<Invoice> _service;

        public InvoiceController(IService<Invoice> service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllInvoices()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdInvoice([FromRoute] int id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
        {
            await _service.Create(invoice);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateInvoice([FromBody] Invoice invoice)
        {
            await _service.Update(invoice);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteInvoice([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
