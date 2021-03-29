using MarriageAgency.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Data
{
    public class MarriageAgencyContext : DbContext
    {
        public MarriageAgencyContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ZodiacSign> ZodiacSigns { get; set; }
    }
}
