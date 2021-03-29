using MarriageAgency.Models;
using MarriageAgency.ViewModels.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.ViewModels
{
    public class CustomerViewModel
    {
        public ICollection<Customer> Customers { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public CustomerFilter CustomerFilter { get; set; }
    }
}
