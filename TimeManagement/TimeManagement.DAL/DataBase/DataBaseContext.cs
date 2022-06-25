using Microsoft.EntityFrameworkCore;
using TimeManagement.Domain.Entities;

namespace TimeManagement.DAL.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Contract> Contracts => Set<Contract>();
        public DbSet<Invoice> Invoices => Set<Invoice>();
        public DbSet<Task> Tasks => Set<Task>();
    }
}