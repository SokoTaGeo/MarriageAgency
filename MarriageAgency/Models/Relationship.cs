using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Models
{
    public class Relationship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desctiption { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public Relationship()
        {
            Customers = new List<Customer>();
        }
    }
}
