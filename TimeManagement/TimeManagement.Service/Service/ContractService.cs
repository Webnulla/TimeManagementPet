using System.Collections.Generic;
using System.Threading.Tasks;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TimeManagement.Service.Service
{
    public class ContractService : IService<Contract>
    {
        private readonly IContractRepository _contractRepository;

        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task Create(Contract item)
        {
            await _contractRepository.Add(item);
        }

        public async Task Update(Contract item)
        {
            var contract = await _contractRepository.Get(item.Id);
            contract.Id = item.Id;
            contract.Name = item.Name;
            contract.Invoice = item.Invoice;
            
            await _contractRepository.Update(contract);
        }

        public async Task Delete(int id)
        {
            await _contractRepository.Delete(id);
        }

        public async Task<Contract> Get(int id)
        {
            var contract = await _contractRepository.Get(id);
            return contract;
        }

        public async Task<IEnumerable<Contract>> GetAll()
        {
            var contract = await _contractRepository.GetAll();
            return contract;
        }
    }
}