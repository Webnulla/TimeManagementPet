using System;
using System.Collections.Generic;

namespace TimeManagement.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsPayed { get; set; }
        public DateTime PayTime { get; set; }
        public List<Task> Tasks { get; set; }
    }
}