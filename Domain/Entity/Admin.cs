using System;

namespace Domain.Entity
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public DateTime Birdate { get; set; }
        public string Password { get; set; }
    }
}
