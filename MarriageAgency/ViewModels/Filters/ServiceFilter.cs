using MarriageAgency.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.ViewModels.Filters
{
    public class ServiceFilter
    {
        public bool Less30Rub { get; set; }
        public bool More100Rub { get; set; }
        public int? EmployeeId { get; set; }
        public SelectList Employees { get; set; }

        public ServiceFilter(bool less30Rub, bool more100Rub, int? employeeId, IList<Employee> employees)
        {
            employees.Insert(0, new Employee()
            {
                Id = 0,
                FullName = "All"
            });

            Less30Rub = less30Rub;
            More100Rub = more100Rub;
            EmployeeId = employeeId;

            Employees = new SelectList(employees, "Id", "FullName", employeeId);
        }
    }
}
