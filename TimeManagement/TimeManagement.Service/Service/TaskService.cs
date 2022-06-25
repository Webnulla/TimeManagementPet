using System.Collections.Generic;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;

namespace TimeManagement.Service.Service
{
    public class TaskService : IService<Task>
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async System.Threading.Tasks.Task Create(Task item)
        {
            await _taskRepository.Add(item);
        }

        public async System.Threading.Tasks.Task Update(Task item)
        {
            var task = await _taskRepository.Get(item.Id);
            task.Id = item.Id;
            task.Name = item.Name;
            task.Price = item.Price;
            task.IsDone = item.IsDone;
            task.IsDoneDate = item.IsDoneDate;
            task.IsTaken = item.IsTaken;
            task.IsTakenDate = item.IsTakenDate;

            await _taskRepository.Update(task);
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            await _taskRepository.Delete(id);
        }

        public async System.Threading.Tasks.Task<Task> Get(int id)
        {
            var task = await _taskRepository.Get(id);
            return task;
        }

        public async System.Threading.Tasks.Task<IEnumerable<Task>> GetAll()
        {
            var tasks = await _taskRepository.GetAll();
            return tasks;
        }
    }
}