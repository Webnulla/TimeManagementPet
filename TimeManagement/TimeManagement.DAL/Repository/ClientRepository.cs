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
    public class ClientRepository : IClientRepository
    {
        private readonly DataBaseContext _context;

        public ClientRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Client> Get(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                throw new ArgumentException("Клиент не найден");
            }

            return client;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            var client = await _context.Clients.ToListAsync();
            return client;
        }

        public async Task Add(Client entity)
        {
            await _context.Clients.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Client entity)
        {
            var client = await _context.Clients.FindAsync(entity.Id);
            if (client == null)
            {
                throw new ArgumentException("Клиент не найден");
            }

            client.Id = entity.Id;
            client.FirstName = entity.FirstName;
            client.LastName = entity.LastName;
            client.Phone = entity.Phone;
            client.Contracts = entity.Contracts;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                throw new ArgumentException("Клиент не найден");
            }

            _context.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}