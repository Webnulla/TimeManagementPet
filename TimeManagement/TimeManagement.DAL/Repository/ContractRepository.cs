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
    public class ContractRepository : IContractRepository
    {
        private readonly DataBaseContext _context;

        public ContractRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Contract> Get(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                throw new ArgumentException("Контракт не найден");
            }

            return contract;
        }

        public async Task<IEnumerable<Contract>> GetAll()
        {
            var contarct = await _context.Contracts.ToListAsync();
            return contarct;
        }

        public async Task Add(Contract entity)
        {
            await _context.Contracts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Contract entity)
        {
            var contract = await _context.Contracts.FindAsync(entity.Id);
            if (contract == null)
            {
                throw new ArgumentException("Контракт не найден");
            }

            contract.Id = entity.Id;
            contract.Name = entity.Name;
            contract.Invoice = entity.Invoice;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                throw new ArgumentException("Контракт не найден");
            }

            _context.Remove(contract);
            await _context.SaveChangesAsync();
        }
    }
}