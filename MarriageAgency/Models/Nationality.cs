using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Models
{
    public class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public Nationality()
        {
            Customers = new List<Customer>();
        }
    }
}
