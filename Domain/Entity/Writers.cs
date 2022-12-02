using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Writers
    {
        public Guid Id { get; set; }
        public string WriterName { get; set; } = string.Empty;
        public string WriterSurname { get; set; } = string.Empty;
        public DateTime BirtDate { get; set; }
        public int Age { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
