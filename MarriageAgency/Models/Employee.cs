using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportData { get; set; }

        public ICollection<Service> Services { get; set; }

        public Employee()
        {
            Services = new List<Service>();
        }
    }
}
