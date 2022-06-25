using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeManagement.DAL.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}