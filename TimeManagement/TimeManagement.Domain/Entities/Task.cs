using System;

namespace TimeManagement.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsTaken { get; set; }
        public DateTime IsTakenDate { get; set; }
        public bool IsDone { get; set; }
        public DateTime IsDoneDate { get; set; }
    }
}