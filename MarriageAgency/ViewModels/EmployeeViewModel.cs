using MarriageAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.ViewModels
{
    public class EmployeeViewModel
    {
        public ICollection<Employee> Employees { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
