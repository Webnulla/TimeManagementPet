using System.Collections.Generic;

namespace TimeManagement.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public IEnumerable<Contract> Contracts { get; set; }
    }
}