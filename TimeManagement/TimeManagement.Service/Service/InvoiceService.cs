using System.Collections.Generic;
using System.Threading.Tasks;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TimeManagement.Service.Service
{
    public class InvoiceService : IService<Invoice>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task Create(Invoice item)
        {
            await _invoiceRepository.Add(item);
        }

        public async Task Update(Invoice item)
        {
            var invoice = await _invoiceRepository.Get(item.Id);
            invoice.Id = item.Id;
            invoice.Name = item.Name;
            invoice.Price = item.Price;
            invoice.IsPayed = item.IsPayed;
            invoice.PayTime = item.PayTime;
            invoice.Tasks = item.Tasks;

            await _invoiceRepository.Update(invoice);
        }

        public async Task Delete(int id)
        {
            await _invoiceRepository.Delete(id);
        }

        public async Task<Invoice> Get(int id)
        {
            var invoice = await _invoiceRepository.Get(id);
            return invoice;
        }

        public async Task<IEnumerable<Invoice>> GetAll()
        {
           var invoice = await _invoiceRepository.GetAll();
           return invoice;
        }
    }
}