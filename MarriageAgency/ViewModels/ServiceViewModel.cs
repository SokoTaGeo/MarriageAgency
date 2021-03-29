using MarriageAgency.Models;
using MarriageAgency.ViewModels.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.ViewModels
{
    public class ServiceViewModel
    {
        public ICollection<Service> Services { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public ServiceFilter ServiceFilter { get; set; }
    }
}
