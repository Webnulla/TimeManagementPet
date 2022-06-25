using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TimeManagement.DAL.DataBase;
using TimeManagement.DAL.Repository.Interfaces;
using TimeManagement.Domain.Entities;

namespace TimeManagement.DAL.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataBaseContext _context;

        public TaskRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task<Task> Get(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                throw new ArgumentException("Задание не найдено");
            }

            return task;
        }

        public async System.Threading.Tasks.Task<IEnumerable<Task>> GetAll()
        {
            var task = await _context.Tasks.ToListAsync();
            return task;
        }

        public async System.Threading.Tasks.Task Add(Task entity)
        {
            await _context.Tasks.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Update(Task entity)
        {
            var task = await _context.Tasks.FindAsync(entity.Id);
            if (task == null)
            {
                throw new ArgumentException("Задание не найдено");
            }

            task.Id = entity.Id;
            task.Name = entity.Name;
            task.Price = entity.Price;
            task.IsDone = entity.IsDone;
            task.IsDoneDate = entity.IsDoneDate;
            task.IsTaken = entity.IsTaken;
            task.IsTakenDate = entity.IsTakenDate;

            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                throw new ArgumentException("Задание не найдено");
            }

            _context.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}