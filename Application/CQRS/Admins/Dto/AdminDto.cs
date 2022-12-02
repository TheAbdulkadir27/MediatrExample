using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CQRS.Admins.Dto
{
    public class AdminDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime Birdate { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
