using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeManagement.DAL.DataBase;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TimeManagement.DAL.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataBaseContext _context;

        public InvoiceRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Invoice> Get(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                throw new ArgumentException("Счет не найден");
            }

            return invoice;
        }

        public async Task<IEnumerable<Invoice>> GetAll()
        {
            var invoice = await _context.Invoices.ToListAsync();
            return invoice;
        }

        public async Task Add(Invoice entity)
        {
            await _context.Invoices.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Invoice entity)
        {
            var invoice = await _context.Invoices.FindAsync(entity.Id);
            if (invoice == null)
            {
                throw new ArgumentException("Счет не найден");
            }

            invoice.Id = entity.Id;
            invoice.Name = entity.Name;
            invoice.Price = entity.Price;
            invoice.Tasks = entity.Tasks;
            invoice.PayTime = entity.PayTime;
            invoice.IsPayed = entity.IsPayed;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                throw new ArgumentException("Счет не найден");
            }

            _context.Remove(invoice);
            await _context.SaveChangesAsync();
        }
    }
}