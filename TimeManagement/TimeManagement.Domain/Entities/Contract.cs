using System;

namespace TimeManagement.Domain.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDateTime => DateTime.Now;
        public Invoice Invoice { get; set; }
    }
}