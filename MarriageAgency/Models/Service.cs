using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Models
{
    public class Service
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }

    }
}
