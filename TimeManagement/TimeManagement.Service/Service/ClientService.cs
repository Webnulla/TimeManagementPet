using System.Collections.Generic;
using System.Threading.Tasks;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TimeManagement.Service.Service
{
    public class ClientService : IService<Client>
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task Create(Client item)
        {
            await _clientRepository.Add(item);
        }

        public async Task Update(Client item)
        {
            var client = await _clientRepository.Get(item.Id);
            client.Id = item.Id;
            client.FirstName = item.FirstName;
            client.LastName = item.LastName;
            client.Phone = item.Phone;
            client.Contracts = item.Contracts;

            await _clientRepository.Update(client);
        }

        public async Task Delete(int id)
        {
            await _clientRepository.Delete(id);
        }

        public async Task<Client> Get(int id)
        {
            var client = await _clientRepository.Get(id);
            return client;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            var client = await _clientRepository.GetAll();
            return client;
        }
    }
}