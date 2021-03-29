using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Models
{
    public class ZodiacSign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public ZodiacSign()
        {
            Customers = new List<Customer>();
        }
    }
}
