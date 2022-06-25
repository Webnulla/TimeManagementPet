using System.Collections.Generic;
using System.Threading.Tasks;
using TimeManagement.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace TimeManagement.Service.Service
{
    public interface IService<T>
    {
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
    }
}