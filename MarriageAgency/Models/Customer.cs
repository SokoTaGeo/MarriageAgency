using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public DateTime BirthdayDate { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int ChildrenCount { get; set; }
        public string MaritalStatus { get; set; }
        public string BadHadits { get; set; }
        public string Hobby { get; set; }
        public string Description { get; set; }
        public int ZodiacSignId { get; set; }
        public int RelationshipId { get; set; }
        public int NationalityId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportData { get; set; }

        public ZodiacSign ZodiacSign { get; set; }
        public Relationship Relationship { get; set; }
        public Nationality Nationality { get; set; }

        public ICollection<Service> Services { get; set; }

        public Customer()
        {
            Services = new List<Service>();
        }
    }
}
